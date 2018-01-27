using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace YYG.WinServer
{
    public partial class MyService : ServiceBase
    {
        public readonly IScheduler scheduler;

        public MyService()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
            InitializeComponent();
        }

        //服务开启执行代码
        protected override void OnStart(string[] args)
        {
            scheduler.Start();           
        }

        //服务结束执行代码
        protected override void OnStop()
        {
            scheduler.Shutdown(false);
        }

        //服务暂停执行代码
        protected override void OnPause()
        {
            scheduler.PauseAll();
            
        }

        //服务恢复执行代码
        protected override void OnContinue()
        {
            scheduler.ResumeAll();
        }

        //系统即将关闭执行代码
        protected override void OnShutdown()
        {
            scheduler.Shutdown(false);
        }

    }
}
