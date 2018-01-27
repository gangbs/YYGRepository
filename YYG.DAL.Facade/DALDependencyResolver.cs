using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using YYG.IRepository;
using YYG.Repository;

namespace YYG.DAL.Facade
{
   public class DALDependencyResolver : IDependencyResolver
    {
        private IKernel ninjectKernel;



        private DALDependencyResolver()
        {
            ninjectKernel = new StandardKernel();
            Binding();
        }

        static DALDependencyResolver instance;
        public static DALDependencyResolver GetInstance()
        {
            if (instance == null)
            {
                instance = new DALDependencyResolver();
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
            //ninjectKernel.Bind<IPoliceRepository>().To<PoliceRepository>().WithConstructorArgument("num", 123);
            ninjectKernel.Bind<DbContext>().To<MyDBContext>();
            ninjectKernel.Bind<IPoliceRepository>().To<PoliceRepository>();
            ninjectKernel.Bind<ISellerRepository>().To<SellerRepository>();
            ninjectKernel.Bind<ISellerBrandRepository>().To<SellerBrandRepository>();
            ninjectKernel.Bind<IVehicleRegistRepository>().To<VehicleRegistRepository>();
            ninjectKernel.Bind<IVehicleInfoRepository>().To<VehicleInfoRepository>();
            ninjectKernel.Bind<IVehicleOwnerRepository>().To<VehicleOwnerRepository>();
            ninjectKernel.Bind<IVehicleLicenseRepository>().To<VehicleLicenseRepository>();
            ninjectKernel.Bind<IVehicleTransferRepository>().To<VehicleTransferRepository>();

        }
    }
}
