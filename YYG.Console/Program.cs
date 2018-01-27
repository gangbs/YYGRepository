using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using YYG.Framework.Quartz;

namespace YYG.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ScheduleServer>();

                x.SetDescription("TDR任务调度服务");
                x.SetDisplayName("TDR任务调度服务");
                x.SetServiceName("TDR任务调度服务");

                x.EnablePauseAndContinue();

            });
        }
    }
}
