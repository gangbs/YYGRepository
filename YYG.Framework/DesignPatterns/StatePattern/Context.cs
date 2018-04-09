using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns.StatePattern
{
   public class Context
    {
        public int StateParam { get; set; }

        private State state { get; set; }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void Request()
        {
            this.state.Handle(this);
        }

    }
}
