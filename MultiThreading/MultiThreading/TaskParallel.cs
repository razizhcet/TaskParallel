using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    /// <summary>
    /// class to show two method working parallely
    /// T:MultiThreading.TaskParallel
    /// </summary>
    class TaskParallel
    {
        /// <summary>
        /// statement for using functions of log4net
        /// F:MultiThreading.TaskParallel.log
        /// </summary>
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(TaskParallel));

        /// <summary>
        /// printMessage() method to perform 1st task task
        /// M:MultiThreading.TaskParallel.printMessage()
        /// </summary>
        /// <returns>return type is void.</returns>
        public static void printMessage()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello world");
            log.Info("Hello world");
        }

        /// <summary>
        /// threadName() method to perform 2nd task task
        /// M:MultiThreading.TaskParallel.threadName()
        /// </summary>
        /// <returns>return type is void.</returns>
        public static void threadName()
        {
            Thread th = Thread.CurrentThread;
            th.Name = "main thread";
            Console.WriteLine("thread name is : " + th.Name);
            log.Info("thread name is : " + th.Name);
        }

        /// <summary>
        /// main method for calling two tasks parallely
        /// M:MultiThreading.TaskParallel.Main(System.String[])
        /// </summary>
        /// <param name="args">string array type parameter.</param>
        /// <returns>return type is void.</returns>
        static void Main(string[] args)
        {
            //Task.Factory.StartNew(() =>{Console.WriteLine("1st method to creating task");});//direct way
            //Task task = new Task(new Action(printMessage));       //using action
            //Task task = new Task(delegate { printMessage(); });   //using delegate
            //Task task = new Task(() => { printMessage(); });  //lambda with unnamed method

            Task task1 = new Task(() => printMessage());    //lambda with named method
            Task task2 = new Task(() => threadName());
            task1.Start();
            task2.Start();
            Console.ReadKey();
        }
    }
}
