using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDBXEditor.Common;

namespace WDBXEditor
{
    public static partial class InstanceManager
    {
        // CA2211: Convertidos a Propiedades
        public static ConcurrentQueue<string> AutoRun { get; set; } = new();
        public static Action AutoRunAdded { get; set; }

        private static Mutex mutex;
        private static NamedPipeManager pipeServer;

        /// <summary>
        /// Checks a mutex to see if an instance is running and decides how to proceed based on this and args
        /// </summary>
        /// <param name="args"></param>
        public static void InstanceCheck(string[] args)
        {
            // Extraemos el comodín oculto si existe
            bool forceNew = false;
            List<string> cleanArgs = [];

            if (args != null)
            {
                foreach (string arg in args)
                {
                    if (arg.Equals("-force", StringComparison.OrdinalIgnoreCase))
                        forceNew = true;
                    else
                        cleanArgs.Add(arg);
                }
            }
            args = [.. cleanArgs];

            static bool ArgCheck(string[] a) => a != null && a.Length > 0 && File.Exists(a[0]);
            bool isOnlyInstance = false;

            if (ArgCheck(args) || args.Length == 0)
            {
                mutex = new Mutex(true, "WDBXEditorMutex", out isOnlyInstance);

                if (forceNew)
                {
                    // Entra por el comodín: Forzamos nueva ventana
                    Program.PrimaryInstance = true;
                }
                else if (!isOnlyInstance && ArgCheck(args))
                {
                    // YA NO PREGUNTAMOS AQUÍ. 
                    // Simplemente le enviamos los datos a la ventana principal para que ella decida.
                    Program.PrimaryInstance = false;
                    SendData(args);
                    return;
                }
                else if (isOnlyInstance)
                {
                    Program.PrimaryInstance = true;
                    pipeServer = new NamedPipeManager();
                    pipeServer.ReceiveString += OpenRequest;
                    pipeServer.StartServer();
                }
                else
                {
                    Program.PrimaryInstance = true;
                }
            }
        }

        public static void LoadDll(string lib)
        {
            string startupDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string stormlibPath = Path.Combine(startupDirectory, lib);
            bool copyDll = true;

            if (File.Exists(stormlibPath)) //If the file exists check if it is the right architecture
            {
                byte[] data = new byte[4096];

                // CA1859: Cambiado Stream s a var s (FileStream)
                using (var s = new FileStream(stormlibPath, FileMode.Open, FileAccess.Read))
                    s.Read(data, 0, 4096);

                int PE_HEADER_ADDR = BitConverter.ToInt32(data, 0x3C);
                bool x86 = BitConverter.ToUInt16(data, PE_HEADER_ADDR + 0x4) == 0x014c; //32bit check
                copyDll = (x86 != !Environment.Is64BitProcess);
            }

            if (copyDll)
            {
                string copypath = Path.Combine(startupDirectory, Environment.Is64BitProcess ? "x64" : "x86", lib);
                if (File.Exists(copypath))
                    File.Copy(copypath, stormlibPath, true);
            }
        }

        /// <summary>
        /// Enqueues recieved file names and launches the AutoRun delegate
        /// </summary>
        /// <param name="filenames"></param>
        public static void OpenRequest(string filenames)
        {
            string[] files = filenames.Split((Char)3);
            Parallel.For(0, files.Length, f =>
            {
                if (Regex.IsMatch(files[f], Constants.FileRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                    AutoRun.Enqueue(files[f]);
            });

            AutoRunAdded?.Invoke();
        }

        public static void Start()
        {
            pipeServer?.StartServer();
        }

        public static void Stop()
        {
            if (pipeServer != null)
            {
                pipeServer.ReceiveString -= OpenRequest;
                pipeServer.StopServer();
            }
        }

        /// <summary>
        /// Opens a new version of the application which bypasses the mutex
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static bool LoadNewInstance(IEnumerable<string> files)
        {
            Stop(); //Stop server

            using Process p = new();
            p.StartInfo.FileName = Application.ExecutablePath;
            p.StartInfo.Arguments = string.Join(" ", files);
            bool started = p.Start();

            while (started && p.MainWindowHandle == IntPtr.Zero) //Await the program to fully load
                Thread.Sleep(50);

            if (Program.PrimaryInstance)
                Start(); //Start server

            return started;
        }

        public static IEnumerable<string> GetFilesToOpen()
        {
            HashSet<string> files = [];
            while (!AutoRun.IsEmpty)
            {
                if (AutoRun.TryDequeue(out string file) && File.Exists(file))
                    files.Add(file);
            }
            return files;
        }

        public static bool IsRunningAsAdmin()
        {
            WindowsPrincipal principal = new(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        #region Send Data
        private static void SendData(string args)
        {
            NamedPipeManager clientPipe = new();
            if (clientPipe.Write(args))
                Environment.Exit(0);
        }

        private static void SendData(string[] args)
        {
            SendData(string.Join(((Char)3).ToString(), args));
        }
        #endregion

        #region Flash Methods
        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        internal struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        public static bool FlashWindow(Form form)
        {
            if (Type.GetType("Mono.Runtime") != null)
                return false;

            FLASHWINFO fInfo = new();

            uint FLASHW_ALL = 3;
            uint FLASHW_TIMERNOFG = 12;

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = form.Handle;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = uint.MaxValue;
            fInfo.dwTimeout = 0;

            return FlashWindowEx(ref fInfo);
        }
        #endregion

    }
}
