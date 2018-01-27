using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using YYG.IRepository;
using YYG.Repository;

namespace YYG.Core
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public MyControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            Binding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                return (IController)ninjectKernel.Get(controllerType);
            }
            catch
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }


        private void Binding()
        {
            //ninjectKernel.Bind<IPoliceRepository>().To<VehicleTransferRepository>().WithConstructorArgument("num", 123);
            //ninjectKernel.Bind<MyRepository1>().ToSelf().WithConstructorArgument("num", 123);
        }
    }
}
