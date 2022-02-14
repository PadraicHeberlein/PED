using System;
using System.Threading.Tasks;

namespace PED
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Startup.CreateDirectories();
            /* If no arguments are detected, 
             * will run in continuous loop 
             * until the user quits.*/
            if (args.Length == 0)
                await Run.WithoutArgs();
            else
                await Run.WithArgs(args);
        }
    }
}
