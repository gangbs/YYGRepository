using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YYG.Framework
{
    public class DemoInterceptor : IInterceptor
    {
        public object Invoke(object obj, string methodName, object[] parameters)
        {
            Console.WriteLine($"before invoke {methodName}");
            object rtn = obj.GetType().GetMethod(methodName).Invoke(obj, parameters);
            Console.WriteLine($"after invoke {methodName}");
            return rtn;
        }
    }

    public class TestClass
    {
        public virtual string GetMessage(int num)
        {
            return $"num is {num}";
        }

        public virtual void ShowMessage(int num)
        {
            string msg= $"num is {num}";
            Console.WriteLine(msg);
        }

        public virtual void ShowMessage2()
        {
            string msg = $"num is 9";
            Console.WriteLine(msg);
        }
    }

}
