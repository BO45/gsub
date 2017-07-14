using gsub.Common;
using gsub.Options;

namespace gsub.Commands
{
    internal class RemoteCommand
    {
        private const string Arguments = "remote -v";

        public static GitExecuteResult TryExecute(RemoteOptions options)
        {
            string args = $"{Arguments}";
            var executeResult = new ProcessTool(options, true).ExecuteGit(args);

            if (executeResult.ProcessExecutionResult.WasExecuted == false || executeResult.ProcessExecutionResult.ExitCode != 0)
            {
                return executeResult;
            }

            return executeResult;
        }
    }
}