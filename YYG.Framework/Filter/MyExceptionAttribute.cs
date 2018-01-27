using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YYG.Framework.Filter
{
   public class MyExceptionAttribute: HandleErrorAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {           
            //filterContext.Result=
        }
    }
}
