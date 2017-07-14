using System;
using System.Linq;
using gsub.Common;
using gsub.Options;

namespace gsub.Commands
{
    internal class PullCommand
    {
        private const string Arguments = "subtree pull ";

        public static GitExecuteResult TryExecute(PullOptions options)
        {
            var config = Configuration.Load();
            var entry = config.Subtrees.FirstOrDefault(c => c.Alias == options.Alias);
            if (entry == null)
            {
                Console.WriteLine($"{options.Alias} not found.");
                return null;
            }

            if (options.Ref != null)
            {
                entry.Ref = options.Ref;
            }

            entry.Squash = options.Squash;
            entry.Message = options.Message;
            string args = $"{Arguments} {entry}";

            var executeResult = new ProcessTool(options, true).ExecuteGit(args);
            if (executeResult.ProcessExecutionResult.WasExecuted == false || executeResult.ProcessExecutionResult.ExitCode != 0)
            {
                Console.WriteLine(executeResult.ProcessExecutionResult.ErrorOutput);
                return executeResult;
            }

            return executeResult;
        }
    }
}