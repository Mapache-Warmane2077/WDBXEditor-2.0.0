using System;
using System.Collections.Generic;
using System.IO;

namespace WDBXEditor.Archives.CASC.Handlers
{
    public class BuildInfo
    {
        public string this[string name]
        {
            get
            {
                if (entries.TryGetValue(name, out string entry))
                    return entry;

                return null;
            }
        }

        readonly Dictionary<string, string> entries = [];

        public BuildInfo(string file)
        {
            using var sr = new StreamReader(file);
            var header = sr.ReadLine().Split(['|', '!']);
            var dataLine = "";

            while ((dataLine = sr.ReadLine()) != null)
            {
                var data = dataLine.Split(['|']);

                if (data.Length != header.Length / 2)
                    throw new InvalidOperationException("Invalid header length");

                // Be sure to get the active build info.
                if (data[1] == "0")
                    continue;

                for (var i = 0; i < data.Length; i++)
                    entries.Add(header[i << 1], data[i]);
            }
        }
    }
}
