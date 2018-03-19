using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MultiThreading
{
    class CancleClass
    {
        static void Main(string[] args)
        {
            //creating the cancelation token  
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            //creating the task  
            Task task = new Task(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancel() called.");
                        return;
                    }

                    Console.WriteLine("Loop value {0}", i);
                }
            }, token);

            Console.WriteLine("Press any key to start task");
            Console.WriteLine("Press any key again to cancel the running task");
            Console.ReadKey();

            //starting the task  
            task.Start();

            //reading a console key  
            Console.ReadKey();

            //canceling the task  
            Console.WriteLine("Canceling task");
            cts.Cancel();

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }
    }
}
