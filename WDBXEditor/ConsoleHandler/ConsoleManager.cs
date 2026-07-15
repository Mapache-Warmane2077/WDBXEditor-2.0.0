using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDBXEditor.Storage;

namespace WDBXEditor.ConsoleHandler
{
    public static class ConsoleManager
    {
        public static bool ConsoleMode { get; set; } = false;

        // CA2211: Convertido a propiedad agregando { get; set; }
        public static Dictionary<string, HandleCommand> CommandHandlers { get; set; } = [];
        public delegate void HandleCommand(string[] args);

        public static void ConsoleMain(string[] args)
        {
            Database.LoadDefinitions().Wait();

            if (CommandHandlers.ContainsKey(args[0].ToLower()))
                InvokeHandler(args[0], [.. args.Skip(1)]);
        }

        public static bool InvokeHandler(string command, params string[] args)
        {
            try
            {
                command = command.ToLower();
                if (CommandHandlers.TryGetValue(command, out HandleCommand value))
                {
                    value.Invoke(args);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                return false;
            }
        }

        public static void LoadCommandDefinitions()
        {
            //Argument commands
            //DefineCommand("-console", ConsoleManager.LoadConsoleMode);
            DefineCommand("-export", ConsoleCommands.ExportArgCommand);
            DefineCommand("-sqldump", ConsoleCommands.SqlDumpArgCommand);
            DefineCommand("-extract", ConsoleCommands.ExtractCommand);
        }

        /// <summary>
        /// Converts args into keyvalue pair
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseCommand(string[] args)
        {
            Dictionary<string, string> keyvalues = [];
            for (int i = 0; i < args.Length; i++)
            {
                if (i == args.Length - 1)
                    break;

                string key = args[i].ToLower();
                string value = args[++i];

                // IDE0056: value.Length - 1 simplificado al operador ^1
                if (value[0] == '"' && value[^1] == '"')
                    value = value[1..^1];

                keyvalues.Add(key, value);
            }

            return keyvalues;
        }

        private static void DefineCommand(string command, HandleCommand handler)
        {
            CommandHandlers[command.ToLower()] = handler;
        }
    }
}