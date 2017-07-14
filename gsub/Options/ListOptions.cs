using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using gsub.Common;

namespace gsub.Options
{
    [Verb("list", HelpText = "Lists currently managed subtrees")]
    internal class ListOptions : CommonOption
    {
        [Usage(ApplicationAlias = Statics.AppName)]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Normal scenario", new ListOptions()); }
        }
    }
}