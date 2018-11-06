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
        bool _loop = true;

        static void Main(string[] args)
        {
            MultiThreadRunner runner = new MultiThreadRunner();
            Thread.CurrentThread.Name = "Main Thread (Program)";
            runner.RunMultipleThreads();


            Program p = new Program();
            p._loop = false;

            runner.cancelWorkerThread = false;
            Thread someThread = new Thread(SomeThread);
            someThread.Start(runner);

            Console.WriteLine("Press any key to cancel");
            Console.ReadKey();
            runner.cancelWorkerThread = true;

            Console.ReadKey();
        }

        private static void SomeThread(object o1)
        {
            MultiThreadRunner threadRunner = (MultiThreadRunner)o1;
            Console.WriteLine("Loop Starting...");
            while (!threadRunner.cancelWorkerThread)
            {
                Thread.Sleep(1000);
                Console.WriteLine("I am also doing work.");
            }
            Console.WriteLine("Loop Stopping...");
        }
    }
}
