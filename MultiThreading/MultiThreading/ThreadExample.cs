using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class MyThread
    {
        public void ThreadName()
        {
            Thread th = Thread.CurrentThread;
            //th.Name = "main thread";
            Console.WriteLine(th.Name+" is running");
        }
        public void Thread1()
        {
            //Thread.Sleep(10000);
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public void Thread2()
        {
            for (int i = 10; i < 20; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    class ThreadExample
    {
        static void Main(string[] args)
        {
            MyThread mt = new MyThread();
            Thread t1 = new Thread(new ThreadStart(mt.ThreadName));
            Thread t4 = new Thread(new ThreadStart(mt.ThreadName));
            Thread t5 = new Thread(new ThreadStart(mt.ThreadName));
            Thread t2 = new Thread(new ThreadStart(mt.Thread1));
            Thread t3 = new Thread(new ThreadStart(mt.Thread2));

            t1.Name = "thread1";
            t4.Name = "thread4";
            t5.Name = "thread5";

            t1.Priority = ThreadPriority.Lowest;
            t4.Priority = ThreadPriority.Normal;
            t5.Priority = ThreadPriority.Highest;

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            //t3.Join();
            //try
            //{
            //    t2.Abort();
            //    t3.Abort();
            //}
            //catch(ThreadAbortException tae)
            //{
            //    Console.WriteLine(tae.Message);
            //}
            Console.ReadKey();
        }
    }
}
