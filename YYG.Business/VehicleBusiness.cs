using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYG.DAL.Facade;
using YYG.Entity;
using YYG.IRepository;

namespace YYG.Business
{
    public class VehicleBusiness
    {
        readonly UnitOfWork uw;
        public VehicleBusiness()
        {
            this.uw = new UnitOfWork();
        }

        public void Search()
        {
            //var p= this.uw.PoliceRepository.Get(true,41);

            // var p2 = this.uw.PoliceRepository.Get(x => x.PoliceID == 41, false);

            // var lst = this.uw.PoliceRepository.GetAll().ToList();

            //var owner = this.uw.VehicleRegistRepository.Get(true, 282).Owner;

            //var tt= this.uw.VehicleRegistRepository.Test();

           //var rep= (ISellerRepository)this.uw.GetRepository(typeof(ISellerRepository));
           // var p= rep.Get(25);

            var rep= (ISellerRepository)this.uw.GetRepository(typeof(ISellerRepository)) ;
           var a= rep.Get(x => x.OwerName.Contains("y"));
            
            //rep.DynamicCondition();
        }

        public void Search(Expression<Func<VehicleInfoEntity, bool>> filter)
        {
            var rep = (IVehicleInfoRepository)this.uw.GetRepository(typeof(IVehicleInfoRepository));
            var a = rep.GetList(filter).ToList();
            //var b = rep.GetList(x=>x.BuyDate<=DateTime.Now&x.BrandID>=0&x.ElectricID==1).ToList();
        }
        public void JoinSearch()
        {
            var rep = (IVehicleRegistRepository)this.uw.GetRepository(typeof(IVehicleRegistRepository));
            rep.Test();
        }


        public void Add()
        {
            // var seller = new SellerEntity { SellerID=1, AccountID=1, AreaCode= "10001", UserRole=3, OperatorID=2, OperatorTime=DateTime.Now, CreatorID=2, CreateTime=DateTime.Now };
            // var sellerBrand = new SellerBrandEntity { SellerID=1, BrandID=1 };

            // this.uw.SellerBrandRepository.Insert(sellerBrand, false);
            // this.uw.SellerRepository.Insert(seller,false);

            //int count= this.uw.Save();

            
        }

        public void TransactionTest1()
        {
            var seller = new SellerEntity
            {
                AccountID = 1,
                AreaCode = "10001",
                UserRole = 3,
                OperatorID = 2,
                OperatorTime = DateTime.Now,
                CreatorID = 2,
                CreateTime = DateTime.Now,
                UserName = "yyg"
            };

            var police = new PoliceEnity
            {
                AccountID = 1,
                AreaCode = "10001",
                UserRole = 3,
                OperatorID = 2,
                OperateTime = DateTime.Now,
                CreatorID = 2,
                CreateTime = DateTime.Now,
                UserName = "yyg"
            };

            ((ISellerRepository)this.uw.GetRepository(typeof(ISellerRepository))).Insert(seller, false);
            ((IPoliceRepository)this.uw.GetRepository(typeof(IPoliceRepository))).Insert(police, false);
            this.uw.Save();
        }

        public void TransactionTest2()
        {
            var seller = new SellerEntity
            {
                AccountID = 1,
                AreaCode = "10001",
                UserRole = 3,
                OperatorID = 2,
                OperatorTime = DateTime.Now,
                CreatorID = 2,
                CreateTime = DateTime.Now,
                UserName = "yyg",
            };
            var sellerBrand = new SellerBrandEntity
            {
                BrandID = 1,
                Seller = seller
            };

            ((ISellerBrandRepository)this.uw.GetRepository(typeof(ISellerBrandRepository))).Insert(sellerBrand);
        }

        public void TransactionTest3()
        {
            ((ISellerRepository)this.uw.GetRepository(typeof(ISellerRepository))).TransactionTest3();
        }

    }
}
