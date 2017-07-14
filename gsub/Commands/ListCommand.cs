using System;
using gsub.Common;
using gsub.Options;

namespace gsub.Commands
{
    internal class ListCommand
    {
        public static GitExecuteResult TryExecute(ListOptions options)
        {
            var config = Configuration.Load();

            foreach (var item in config.Subtrees)
            {
                Console.WriteLine($"[{item.Alias}]");
                Console.WriteLine($"Prefix: {item.Prefix} => {Statics.GitRootPath}/{item.Prefix}");
                Console.WriteLine($"Url: {item.Url}");
                Console.WriteLine($"Ref: {item.Ref}");
                Console.WriteLine();
            }

            return  new GitExecuteResult();
        }
    }
}