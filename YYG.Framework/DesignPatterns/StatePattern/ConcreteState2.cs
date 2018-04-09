using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns.StatePattern
{
    public class ConcreteState2 : State
    {
        public override void Handle(Context context)
        {
            if (context.StateParam < 20)
            {
                //本状态的处理
            }
            else
            {
                context.SetState(new ConcreteState3());
                context.Request();
            }
        }
    }
}
