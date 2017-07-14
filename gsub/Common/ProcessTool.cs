using System;
using System.Diagnostics;
using System.Text;
using gsub.Options;

namespace gsub.Common
{
    /// <summary>
    /// Handles Process creation, capturing of output and results of execution.
    /// </summary>
    internal class ProcessTool
    {
        private readonly StringBuilder errorOutput = new StringBuilder();
        private readonly CommonOption options;
        private readonly bool outputToStdOut;
        private readonly StringBuilder standardOutput = new StringBuilder();

        public ProcessTool(CommonOption options, bool outputToStdOut)
        {
            this.outputToStdOut = outputToStdOut;
            this.options = options;
        }

        public ProcessExecutionResult Execute(string execPath, string parameters)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(execPath, parameters)
                {
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            };

            var startTime = DateTime.UtcNow;
            var result = new ProcessExecutionResult {WasExecuted = false};
            if (options.Verbose)
            {
                Console.WriteLine($"() => {execPath} {parameters}");
            }

            process.OutputDataReceived += Process_OutputDataReceived;
            process.ErrorDataReceived += Process_ErrorDataReceived;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            catch (Exception e)
            {
                return result;
            }


            // read chunk-wise while process is running.
            process.WaitForExit();

            result.StandardOutput = standardOutput.ToString();
            result.ErrorOutput = errorOutput.ToString();

            result.ExecutionDuration = DateTime.UtcNow - startTime;
            result.ExitCode = process.ExitCode;
            result.WasExecuted = true;
            return result;
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string errorTemp = e.Data;
            if (outputToStdOut)
            {
                Console.WriteLine(errorTemp);
            }
            errorOutput.Append(errorTemp);
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            string stdoutTemp = e.Data;
            if (outputToStdOut)
            {
                Console.WriteLine(stdoutTemp);
            }
            standardOutput.Append(stdoutTemp);
        }

        private void ReadOutputs(Process process)
        {
            string stdoutTemp = process.StandardOutput.ReadToEnd();
            if (outputToStdOut)
            {
                Console.Write(stdoutTemp);
            }
            standardOutput.Append(stdoutTemp);

            string errorTemp = process.StandardError.ReadToEnd();

            errorOutput.Append(errorTemp);
        }

        public GitExecuteResult ExecuteGit(string parameters)
        {
            var result = new GitExecuteResult();
            var execResult = Execute("git", parameters);
            result.ProcessExecutionResult = execResult;
            return result;
        }
    }
}