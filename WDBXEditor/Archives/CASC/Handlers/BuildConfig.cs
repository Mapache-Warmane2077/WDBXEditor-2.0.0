using System;
using System.Collections.Generic;
using System.IO;
using WDBXEditor.Archives.CASC.Misc;

namespace WDBXEditor.Archives.CASC.Handlers
{
    public class BuildConfig
    {
        public string[] this[string name]
        {
            get
            {

                if (entries.TryGetValue(name, out string[] entry))
                    return entry;

                return null;
            }
        }

        readonly Dictionary<string, string[]> entries = [];

        public BuildConfig(string wowPath, string buildKey)
        {
            using var sr = new StreamReader($"{wowPath}/Data/config/{buildKey.GetHexAt(0)}/{buildKey.GetHexAt(2)}/{buildKey}");
            while (!sr.EndOfStream)
            {
                var data = sr.ReadLine().Split(['='], StringSplitOptions.RemoveEmptyEntries);

                if (data.Length < 2)
                    continue;

                var key = data[0].Trim();
                var value = data[1].Split([' '], StringSplitOptions.RemoveEmptyEntries);

                entries.Add(key, value);
            }
        }
    }
}
