using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datetime = DateTime.Now;
            double milliseconds = (datetime.Millisecond) +
                (datetime.Second * 1000) +
                (datetime.Minute * 60 * 1000) +
                (datetime.Hour * 60 * 60 * 1000);

            double ticks = datetime.Ticks / TimeSpan.TicksPerMillisecond;

            Console.WriteLine(milliseconds);
            Console.WriteLine(ticks);

            Thread.Sleep(5000);

            DateTime datetime2 = DateTime.Now;
            double milliseconds2 = (datetime2.Millisecond) +
                (datetime2.Second * 1000) +
                (datetime2.Minute * 60 * 1000) +
                (datetime2.Hour * 60 * 60 * 1000);

            double ticks2 = datetime2.Ticks / TimeSpan.TicksPerMillisecond;

            Console.WriteLine(milliseconds);
            Console.WriteLine(ticks);

            Console.WriteLine(milliseconds2 - milliseconds);
            Console.WriteLine(ticks2 - ticks);

            Console.WriteLine("Hello");
            Thread.Sleep(5000);

        }
    }
}
