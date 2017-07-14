using System;
using System.IO;
using System.Reflection;
using gsub.Options;

namespace gsub.Common
{
    internal static class Statics
    {
        public const string AppName = "gsub";

        
        /// <summary>
        /// Gets the directory location of the console application
        /// </summary>
        public static string EntryPointPath => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);


        /// <summary>
        ///     Returns the path where .git is located
        /// </summary>
        public static string GitRootPath
        {
            get
            {
                var result = new ProcessTool(new CommonOption(), false).ExecuteGit("rev-parse --show-toplevel");

                if (result.ProcessExecutionResult.WasExecuted && result.ProcessExecutionResult.ExitCode == 0)
                {
                    return result.ProcessExecutionResult.StandardOutput.TrimEnd(Environment.NewLine.ToCharArray());
                }
                return null;
            }
        }
    }
}