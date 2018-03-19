using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class ThreadSyncronization
    {
        public void Thread1()
        {
            lock (this)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public void Thread2()
        {
            lock (this)
            {
                for (int i = 10; i < 20; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Main(string[] args)
        {
            ThreadSyncronization tsy = new ThreadSyncronization();
            Thread t1 = new Thread(new ThreadStart(tsy.Thread1));
            Thread t2 = new Thread(new ThreadStart(tsy.Thread2));
            t2.Priority = ThreadPriority.Highest;
            t1.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();

            Console.ReadKey();
        }
    }
}
