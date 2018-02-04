using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace YYG.Framework.Threads
{
   public class TimeHelper
    {
        //System.Threading.Timer类可用来在某个时间后间断性地调用某个方法
        private static void ThreadingTimer()
        {
            //using语句相当于最后调用了t1.Dispose()来释放资源
            using (var t1 = new System.Threading.Timer(
               TimeAction, null, TimeSpan.FromSeconds(2),
               TimeSpan.FromSeconds(3)))
            {
              Thread.Sleep(15000);               
            }
        }

        static void TimeAction(object o)
        {
            Console.WriteLine("System.Threading.Timer {0:T},Thread:{1}", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
