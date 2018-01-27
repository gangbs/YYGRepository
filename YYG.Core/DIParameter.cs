using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Activation;
using Ninject.Planning.Targets;

namespace YYG.Core
{
    public class DIParameter : IParameter
    {
        readonly string name;
        readonly object value;
        public DIParameter(string name,object value)
        {
            this.name = name;
            this.value = value;
        }


        public string Name
        {
            get
            {
                return name;
            }
        }

        public bool ShouldInherit
        {
            get
            {
               return true;
            }
        }

        public bool Equals(IParameter other)
        {
            throw new NotImplementedException();
        }

        public object GetValue(IContext context, ITarget target)
        {
            return this.value;
        }
    }
}
