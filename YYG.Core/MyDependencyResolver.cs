using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using YYG.IRepository;
using YYG.Repository;

namespace YYG.Core
{
    public class MyDependencyResolver : IDependencyResolver
    {
        private IKernel ninjectKernel;
        private MyDependencyResolver()
        {
            ninjectKernel = new StandardKernel();
            Binding();
        }

        static MyDependencyResolver instance;
        public static MyDependencyResolver GetInstance()
        {
            if(instance==null)
            {
                instance =new MyDependencyResolver();
            }
            return instance;
        }


        public object GetService(Type serviceType)
        {
            try
            {
                return ninjectKernel.Get(serviceType);
            }
            catch
            {
                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return ninjectKernel.GetAll(serviceType);
            }
            catch
            {
                return null;
            }
        }

        private void Binding()
        {
            //ninjectKernel.Bind<IPoliceRepository>().To<VehicleTransferRepository>().WithConstructorArgument("num", 123);
            //ninjectKernel.Bind<VehicleTransferRepository>().ToSelf().WithConstructorArgument("num", 123);
        }
    }
}
