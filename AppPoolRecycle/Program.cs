using System;

namespace AppPoolRecycle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new AppPoolRecycleCommand(new AppPoolRecycleConfig(args))
                    .Execute();

                Environment.ExitCode = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.ExitCode = 1;
            }
        }
    }
}
