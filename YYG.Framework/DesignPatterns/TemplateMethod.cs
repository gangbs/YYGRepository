using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DesignPatterns
{
   public abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
        }
    }

    public class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            throw new NotImplementedException();
        }

        public override void PrimitiveOperation2()
        {
            throw new NotImplementedException();
        }
    }

    public class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            throw new NotImplementedException();
        }

        public override void PrimitiveOperation2()
        {
            throw new NotImplementedException();
        }
    }
}
