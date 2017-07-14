using CommandLine;
using gsub.Commands;
using gsub.Options;

namespace gsub
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<AddOptions, ListOptions, RemoveOptions, PullOptions, PushOptions, RemoteOptions,RenameOptions>(args).WithParsed<AddOptions>(t => AddCommand.TryExecute(t))
                .WithParsed<RemoveOptions>(t => RemoveCommand.TryExecute(t))
                .WithParsed<ListOptions>(t => ListCommand.TryExecute(t))
                .WithParsed<PullOptions>(t => PullCommand.TryExecute(t))
                .WithParsed<PushOptions>(t => PushCommand.TryExecute(t))
                .WithParsed<RemoteOptions>(t => RemoteCommand.TryExecute(t))
                .WithParsed<RenameOptions>(t => RenameCommand.TryExecute(t));
        }
    }
}