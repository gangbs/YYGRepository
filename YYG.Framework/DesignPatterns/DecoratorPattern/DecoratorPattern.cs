using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns.DecoratorPattern
{
    /// <summary>
    /// 抽象主题
    /// </summary>
    public abstract class AbsSubject
    {
        public abstract void DoSomething();
    }

    /// <summary>
    /// 具体主题，即被装饰的类
    /// </summary>
    public class ConSubject: AbsSubject
    {
        public override void DoSomething()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 抽象装饰者，完全代替了被装饰者的功能
    /// </summary>
    public abstract class AbsDecorator: AbsSubject
    {
        readonly AbsSubject obj;
        public AbsDecorator(AbsSubject obj)
        {
            this.obj = obj;
        }

        public override void DoSomething()
        {
            if(obj!=null)
            {
                this.obj.DoSomething();
            }
        }

    }

    /// <summary>
    /// 具体装饰者
    /// </summary>
    public class ConDecorator : AbsDecorator
    {
        public ConDecorator(AbsSubject obj) : base(obj) { }


        public override void DoSomething()
        {
            base.DoSomething();//执行obj的dosomething
            DoSomethingOther();//执行当前装饰者类具体的装饰
        }

        public void DoSomethingOther()
        {

        }
    }


    public class DecoratorClient
    {
        public void ClientOperation()
        {

        }
    }
}
