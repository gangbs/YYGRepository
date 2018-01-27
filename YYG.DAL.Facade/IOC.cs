using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.IRepository;
using YYG.Repository;

namespace YYG.DAL.Facade
{
   public class IOC
    {
        private IKernel ninjectKernel;
        public readonly DbContext context;

        public IOC()
        {
            ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<DbContext>().To<MyDBContext>();
            //context= (DbContext)ninjectKernel.Get(typeof(DbContext));
            context = new MyDBContext();
            Binding();
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


        private void Binding()
        {
            ninjectKernel.Bind<IPoliceRepository>().To<PoliceRepository>().WithConstructorArgument(typeof(DbContext),context);
            ninjectKernel.Bind<ISellerRepository>().To<SellerRepository>().WithConstructorArgument(typeof(DbContext), context); ;
            ninjectKernel.Bind<ISellerBrandRepository>().To<SellerBrandRepository>().WithConstructorArgument(typeof(DbContext), context); ;
            ninjectKernel.Bind<IVehicleRegistRepository>().To<VehicleRegistRepository>().WithConstructorArgument(typeof(DbContext), context); ;
            ninjectKernel.Bind<IVehicleInfoRepository>().To<VehicleInfoRepository>().WithConstructorArgument(typeof(DbContext), context); ;
            ninjectKernel.Bind<IVehicleOwnerRepository>().To<VehicleOwnerRepository>().WithConstructorArgument(typeof(DbContext), context); ;
            ninjectKernel.Bind<IVehicleLicenseRepository>().To<VehicleLicenseRepository>().WithConstructorArgument(typeof(DbContext), context); ;
            ninjectKernel.Bind<IVehicleTransferRepository>().To<VehicleTransferRepository>().WithConstructorArgument(typeof(DbContext), context);

        }

    }
}
