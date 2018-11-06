using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace AsynchronousFileRead
{
    class FileReader
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("FileReader");
        public async Task<int> ReadFileAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var fileStream = new FileStream("SampleFile.txt", FileMode.Open);
            var buffer = new byte[fileStream.Length];
            var totalBytesRead = fileStream.ReadAsync(buffer, 0, buffer.Length);

            log.Debug("after ReadAsync call");
            int length = await totalBytesRead;
            sw.Stop();
            Thread.Sleep(2000);

            log.Debug($"Total time taken to read file async is: {sw.Elapsed.TotalSeconds}");
            return length;
        }

        public int ReadSync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var fileStream = new FileStream("SampleFile1.txt", FileMode.Open);
            var buffer = new byte[fileStream.Length];
            var totalBytesRead = fileStream.Read(buffer, 0, buffer.Length);

            log.Debug("After read call");

            sw.Stop();

            log.Debug($"Total time taken to read file sync is: {sw.Elapsed.TotalSeconds}");

            return totalBytesRead;
        }
    }
}
