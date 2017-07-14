using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using gsub.Common;

namespace gsub.Options
{
    [Verb("add", HelpText = "Adds a subtree alias")]
    internal class AddOptions : CommonOption
    {
        [Option('a', "alias", HelpText = "Alias to use for subtree", Required = true)]
        public string Alias { get; set; }

        [Option('p', "prefix", HelpText = "Prefix path to subtree", Required = true)]
        public string Prefix { get; set; }

        [Option('u', "url", HelpText = "Remote URL of subtree", Required = true)]
        public string Url { get; set; }

        [Option('r', "ref", HelpText = "Ref like master", Required = true)]
        public string Ref { get; set; }

        [Option('s', "squash", HelpText = "Squash commits")]
        public bool Squash { get; set; }

        [Option('m', "message", HelpText = "Commit message for merge")]
        public string Message { get; set; }

        [Usage(ApplicationAlias = Statics.AppName)]
        public static IEnumerable<Example> Examples
        {
            get { yield return new Example("Normal scenario", new AddOptions {Alias = "remote1", Prefix = "remote1/src", Url = "https://github.com/remote1", Ref = "master", Squash = true, Message = "Added remote1"}); }
        }

        public override string ToString()
        {
            var message = "";
            if (!string.IsNullOrEmpty(Message))
            {
                message = $"--message \"{Message}\" ";
            }
            return $"{message}--prefix={Prefix} {Url} {Ref} {(Squash ? "--squash" : "")}";
        }
    }
}