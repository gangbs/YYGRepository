using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using YYG.Framework.Quartz;

namespace YYG.WinServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MyService()
            };
            ServiceBase.Run(ServicesToRun);

            //HostFactory.Run(x =>
            //{
            //    x.Service<ScheduleServer>();

            //    x.SetDescription("TDR任务调度服务");
            //    x.SetDisplayName("TDR任务调度服务");
            //    x.SetServiceName("TDR任务调度服务");

            //    x.EnablePauseAndContinue();

            //});


        }
    }
}
