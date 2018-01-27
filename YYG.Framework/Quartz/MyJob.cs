using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.Quartz
{
    public class MyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            WriteTextLog("测试", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public static void WriteTextLog(string fileName, string log)
        {
            string filePath = @"C:\publish\log";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fileFullPath =  $"{filePath}\\{fileName}.txt";

            StringBuilder str = new StringBuilder();
            str.Append(log + "\r\n");

            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
    }
}
