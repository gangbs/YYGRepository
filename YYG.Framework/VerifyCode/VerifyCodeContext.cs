using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
   public class VerifyCodeContext
    {
        VerifyCodeStrategy strategy;

        public VerifyCodeContext(VerifyCodeStrategy strategy)
        {
            this.strategy = strategy;
        }

        public string GenVerifyCode(int num)
        {
            return this.strategy.GenCode(num);
        }

    }
}
