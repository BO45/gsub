using System;
using gsub.Common;
using gsub.Options;

namespace gsub.Commands
{
    internal class AddCommand
    {
        private const string Arguments = "subtree add ";

        public static GitExecuteResult TryExecute(AddOptions options)
        {
            string args = $"{Arguments} {options}";

            var executeResult = new ProcessTool(options, true).ExecuteGit(args);
            if (executeResult.ProcessExecutionResult.WasExecuted == false || executeResult.ProcessExecutionResult.ExitCode != 0)
            {
                Console.WriteLine(executeResult.ProcessExecutionResult.ErrorOutput);
                return executeResult;
            }

            SaveOptionToConfig(options);

            return executeResult;
        }

        private static void SaveOptionToConfig(AddOptions options)
        {
            var config = Configuration.Load();

            if (config.Subtrees.Exists(t => t.Alias == options.Alias))
            {
                Console.WriteLine($"alias {options.Alias} already exists.");
                return;
            }

            config.Subtrees.Add(options);
            config.Save();
        }
    }
}