using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns.ProxyPattern
{
    /// <summary>
    /// 抽象主题，定义了真实主题和代理的规范
    /// </summary>
    public abstract class AbsSubject
    {
        public abstract void Operation();
    }

    /// <summary>
    /// 真实主题
    /// </summary>
    public class ConSubject : AbsSubject
    {
        public override void Operation()
        {
            //doSomething
        }
    }

    /// <summary>
    /// 代理类，保持对真实主题的引用
    /// </summary>
    public class Proxy: AbsSubject
    {
        readonly ConSubject obj;

        public Proxy()
        {
            this.obj = new ConSubject();//真实主题是在代理类内部生成，不同于装饰者模式（由外部传入，如构造函数注入）
        }

        public override void Operation()
        {
            this.BeforeOperation();
            this.obj.Operation();
            this.AfterOperation();
        }

        public void BeforeOperation()
        {
            throw new NotImplementedException();
        }

        public void AfterOperation()
        {
            throw new NotImplementedException();
        }
    }
}
