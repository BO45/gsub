using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using gsub.Common;

namespace gsub.Options
{
    [Verb("rename", HelpText = "Renames an alias")]
    internal class RenameOptions : CommonOption
    {
        [Option('f', "from", HelpText = "Original alias name", Required = true)]
        public string From { get; set; }

        [Option('t', "to", HelpText = "New alias name", Required = true)]
        public string To { get; set; }

        [Usage(ApplicationAlias = Statics.AppName)]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Normal scenario", new RenameOptions {From = "remote1", To = "remote2"}); }
        }
    }
}