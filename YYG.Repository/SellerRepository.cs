using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYG.Entity;
using YYG.IRepository;

namespace YYG.Repository
{
   public class SellerRepository : BaseRepository<SellerEntity>, ISellerRepository
    {
        public SellerRepository(DbContext context):base(context)
        {
        }

        public void DynamicCondition()
        {
           var parameter= Expression.Parameter(typeof(SellerEntity));
            var constant = Expression.Constant("滨江区");
            var member = Expression.PropertyOrField(parameter, nameof(SellerEntity.ShopAddress));
            var query = Expression.Equal(member, constant);
            var exp = Expression.Lambda<Func<SellerEntity, bool>>(query, parameter);

          var lst=  this.GetList(exp);
        }

        public void TransactionTest3()
        {
            string sql = $"update t_seller_brand t set t.BrandID=2";

            var seller = new SellerEntity
            {
                AccountID = 1,
                AreaCode = "10001",
                UserRole = 3,
                OperatorID = 2,
                OperatorTime = DateTime.Now,
                CreatorID = 2,
                CreateTime = DateTime.Now              
            };

            using (var tt = this.context.Database.BeginTransaction())
            {               
                try
                {
                    this.ExcuteSqlCommand(sql, new object[] { });
                    this.Insert(seller, false);
                    int count = this.context.SaveChanges();
                    tt.Commit();
                }
                catch
                {
                    tt.Rollback();
                }
            }


        }


    }
}
