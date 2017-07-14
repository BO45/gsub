using System.Collections.Generic;
using System.IO;
using gsub.Common;
using gsub.Options;

namespace gsub
{
    internal class Configuration
    {
        public List<AddOptions> Subtrees { get; set; } = new List<AddOptions>();

        public static Configuration Load()
        {
            return File.Exists($"{Statics.GitRootPath}/{Statics.AppName}.config.json") == false ? new Configuration() : SerializationHelper.Deserialize<Configuration>(File.ReadAllText($"{Statics.GitRootPath}/{Statics.AppName}.config.json"));
        }

        public void Save()
        {
            SerializationHelper.SerializeToFile(this, $"{Statics.GitRootPath}/{Statics.AppName}.config.json");
        }
    }
}