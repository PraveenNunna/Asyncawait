using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsynchronousFileRead
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Program");

        static void Main(string[] args)
        {
            MultiThreadRunner runner = new MultiThreadRunner();
            Thread.CurrentThread.Name = "Main Thread (Program)";
            runner.RunMultipleThreads();

            Console.ReadKey();
        }
    }
}
