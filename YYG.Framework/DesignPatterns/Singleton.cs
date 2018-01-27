using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns
{
    /// <summary>
    /// 单例模式
    /// </summary>
   public class Singleton
    {
        private static Singleton instance;
        private readonly object locker = new object();
        private Singleton()
        {

        }
        
        public Singleton GetInstance()
        {
            if(instance==null)//双重锁定，使instance!=null时可以直接返回，不必再去作加锁操作，提高性能
            {
                lock(locker)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }

    }
}
