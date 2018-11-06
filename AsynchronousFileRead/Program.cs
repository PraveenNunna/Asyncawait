using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsynchronousFileRead
{
    //Run in release mode.
    //Remove and keep volatile keyword for _loop variable.
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Program");

        //volatile bool cancelThread = true;

        bool cancelThread = true;

        static void Main(string[] args)
        {
            Program program = new Program();

            Thread workerThread = new Thread(DoWork);
            workerThread.Start(program);
            Console.WriteLine("Enter any key to cancel work.");
            Console.ReadKey();

            program.cancelThread = false;
            Console.WriteLine("Value Set to false");
        }

        private static void DoWork(object program)
        {
            Program prog = (Program)program;
            Console.WriteLine("Loop Starting...");
            while (prog.cancelThread)
            {
                //Thread.Sleep(1000);
                //Console.WriteLine("I am working....`");
            }
            Console.WriteLine("Loop Stopping...");
        }
    }
}
