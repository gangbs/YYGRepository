using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns.StatePattern
{
    public class ConcreteState1 : State
    {
        public override void Handle(Context context)
        {
            if(context.StateParam<10)
            {
                //本状态的处理
            }
            else
            {
                context.SetState(new ConcreteState2());
                context.Request();
            }
        }
    }
}
