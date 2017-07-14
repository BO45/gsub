using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using gsub.Common;

namespace gsub.Options
{
    [Verb("pull", HelpText = "Pulls from a subtree alias")]
    internal class PullOptions : CommonOption
    {
        [Option('a', "alias", HelpText = "Alias to subtree", Required = true)]
        public string Alias { get; set; }

        [Option('r', "ref", HelpText = "Alternative ref, other than the one used when added")]
        public string Ref { get; set; }

        [Option('s', "squash", HelpText = "Squash commits")]
        public bool Squash { get; set; }

        [Option('m', "message", HelpText = "Commit message for merge")]
        public string Message { get; set; }


        [Usage(ApplicationAlias = Statics.AppName)]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Normal scenario", new PullOptions {Alias = "remote1", Ref = "develop", Squash = true}); }
        }
    }
}