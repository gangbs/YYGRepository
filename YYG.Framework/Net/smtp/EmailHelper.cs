using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
   public class EmailHelper
    {
        public static void SendEmail()
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.qq.com";
            client.Port = 25;

            MailMessage msg = new MailMessage();
            msg.Sender = new MailAddress("123@qq.com", "yyg");
            msg.To.Add("456@qq.com");
            msg.CC.Add("789@qq.com");
            msg.Subject = "XX周报";
            msg.Body = "xx周作了什么";
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;

            client.Credentials = new NetworkCredential("gang", "123456");
            client.Send(msg);
        }
    }
}
