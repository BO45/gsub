using System;

namespace gsub.Common
{
    internal class ProcessExecutionResult
    {
        public bool WasExecuted { get; set; }
        public string StandardOutput { get; set; }
        public string ErrorOutput { get; set; }
        public TimeSpan ExecutionDuration { get; set; }
        public int ExitCode { get; set; }
    }
}