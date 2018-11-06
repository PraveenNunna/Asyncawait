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
            var fileReader = new FileReader();
            var task = fileReader.ReadFileAsync();

            log.Debug("After ReadFileAsync in Program: {task.Result}");

            fileReader.ReadSync();
            log.Debug("After ReadSync in Program");


            log.Debug($"After Program complete: {task.Result}");
            Console.ReadKey();
        }
    }
}
