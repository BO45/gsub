using System;
using System.Linq;
using gsub.Common;
using gsub.Options;

namespace gsub.Commands
{
    internal class RenameCommand
    {
        public static GitExecuteResult TryExecute(RenameOptions options)
        {
            SaveOptionToConfig(options);

            return new GitExecuteResult();
        }

        private static void SaveOptionToConfig(RenameOptions options)
        {
            var config = Configuration.Load();
            var from = config.Subtrees.FirstOrDefault(t => t.Alias == options.From);

            if (from == null)
            {
                Console.WriteLine($"Alias {options.From} not found.");
                return;
            }

            if (config.Subtrees.Exists(t => t.Alias == options.To))
            {
                Console.WriteLine($"Alias {options.To} already exists.");
                return;
            }

            from.Alias = options.To;
            
            config.Save();

            Console.WriteLine($"{options.From} was renamed to {options.To}.");
        }
    }
}