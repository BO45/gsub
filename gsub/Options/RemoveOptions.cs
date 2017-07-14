using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using gsub.Common;

namespace gsub.Options
{
    [Verb("remove", HelpText = "Removes a subtree alias")]
    internal class RemoveOptions : CommonOption
    {
        [Option('a', "alias", HelpText = "Alias to subtree", Required = true)]
        public string Alias { get; set; }


        [Usage(ApplicationAlias = Statics.AppName)]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Normal scenario", new RemoveOptions {Alias = "remote1"}); }
        }
    }
}