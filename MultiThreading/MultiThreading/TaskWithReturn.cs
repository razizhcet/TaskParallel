using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreading
{
    class TaskWithReturn
    {
        public void taskReturnType()
        {
            var t = Task<int>.Run(() =>
            {
                int max = 100000;
                int val = 0;
                for(val = 0; val <= max; val++)
                {
                    if(val == max/2 && DateTime.Now.Hour <= 12)
                    {
                        val++;
                        break;
                    }
                }
                return val;
            });
            Console.WriteLine("final value:" + t.Result);
        }
        static void Main(string[] args)
        {
            TaskWithReturn twr = new TaskWithReturn();
            twr.taskReturnType();
            Console.ReadKey();
        }
    }
}
