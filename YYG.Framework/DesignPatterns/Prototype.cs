using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns
{
    public class Prototype : ICloneable
    {
        public object Clone()
        {
           return this.MemberwiseClone();
        }
    }
}
