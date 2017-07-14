using CommandLine;

namespace gsub.Options
{
    internal class CommonOption
    {
        public CommonOption()
        {
            Verbose = false;
        }

        [Option('v', "verbose", HelpText = "Increase verbose output")]
        public bool Verbose { get; set; }
    }
}