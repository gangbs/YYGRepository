using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.ORM
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited =false)]
    public class CompareAttribute : Attribute
    {
        public readonly CompareEnum compare;
        public int Order { get; set; }
        public string ColumnName { get; set; }
        
        public CompareAttribute(CompareEnum compare)
        {
            this.compare = compare;
        }
    }
}
