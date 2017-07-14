using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using gsub.Common;

namespace gsub.Options
{
    [Verb("push", HelpText = "Pushes to a subtree alias")]
    internal class PushOptions : CommonOption
    {
        [Option('a', "alias", HelpText = "Alias to subtree", Required = true)]
        public string Alias { get; set; }

        [Option('r', "ref", HelpText = "Alternative ref, other than the one used when added")]
        public string Ref { get; set; }

        [Option('s', "squash", HelpText = "Squash commits")]
        public bool Squash { get; set; }

        [Usage(ApplicationAlias = Statics.AppName)]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Normal scenario", new PushOptions {Alias = "remote1", Ref = "develop", Squash = true}); }
        }
    }
}