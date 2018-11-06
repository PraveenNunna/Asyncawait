using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsynchronousFileRead
{
    public class MultiThreadRunner
    {
        public bool cancelWorkerThread = false;

        public void RunMultipleThreads()
        {
            var hiThread = new Thread(Sayhi);
            hiThread.Name = "Print Thread";
            hiThread.Start();
            hiThread.Join();

            var workerThread = new Thread(DoWork);
            workerThread.Name = "Main Thread";
            workerThread.Start();
            Console.WriteLine("Press any key to exit main Thread");
            Console.ReadKey();
            cancelWorkerThread = true;
            Console.WriteLine("Current thread name is : " + Thread.CurrentThread.Name);
            workerThread.Join();

            var byeThread = new Thread(SayBye);
            byeThread.Name = "Bye Thread";
            byeThread.Start("Bye");

        }

        private void DoWork()
        {
            while (!cancelWorkerThread)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"I am working right now.");
            }
        }

        private void Sayhi()
        {
            Console.WriteLine($"Hello from: {Thread.CurrentThread.Name} ");
        }

        private void SayBye(object wish)
        {
            Console.WriteLine($"{wish.ToString()} from: {Thread.CurrentThread.Name} ");
        }
    }
}
