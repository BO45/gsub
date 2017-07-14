using System;
using System.Linq;
using gsub.Common;
using gsub.Options;

namespace gsub.Commands
{
    internal class PushCommand
    {
        private const string Arguments = "subtree push ";

        public static GitExecuteResult TryExecute(PushOptions options)
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