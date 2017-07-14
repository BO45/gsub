using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using gsub.Common;

namespace gsub.Options
{
    [Verb("remote", HelpText = "Shows remotes")]
    internal class RemoteOptions : CommonOption
    {
        [Usage(ApplicationAlias = Statics.AppName)]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Normal scenario", new RemoteOptions()); }
        }
    }
}