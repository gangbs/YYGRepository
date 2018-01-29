using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYG.DAL.Facade;
using YYG.DTO;
using YYG.Entity;
using YYG.Framework.ORM;
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

        public void CommonSearch()
        {
            var rep = (IPoliceRepository)this.uw.GetRepository(typeof(IPoliceRepository));
           var lst= rep.GetList(x => x.AreaCode.StartsWith("10001"));
        }

        /// <summary>
        /// 多表连接，动态查询条件
        /// </summary>
        public void ManyTableDynamicCondition()
        {
            var query = new VehicleQueryDto();
            query.CarNo ="9";
            var filter = QueryExpression.CreateExpression<VehicleInfoDto, VehicleQueryDto>(query);
            var rep= (IVehicleRegistRepository)this.uw.GetRepository(typeof(IVehicleRegistRepository));
            int count;
           var lst= rep.GetInfoList(filter, 10, 1, out count);
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
