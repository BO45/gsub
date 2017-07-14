using System;
using gsub.Common;
using gsub.Options;

namespace gsub.Commands
{
    internal class RemoveCommand
    {
        public static GitExecuteResult TryExecute(RemoveOptions options)
        {
            SaveOptionToConfig(options);

            return new GitExecuteResult();
        }

        private static void SaveOptionToConfig(RemoveOptions options)
        {
            var config = Configuration.Load();

            int count = config.Subtrees.RemoveAll(t => t.Alias == options.Alias);
            config.Save();

            if (count > 0)
            {
                Console.WriteLine($"{options.Alias} was removed.");
            }
            else
            {
                Console.WriteLine($"{options.Alias} not found.");
            }
        }
    }
}