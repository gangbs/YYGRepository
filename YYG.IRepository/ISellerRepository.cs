using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Entity;

namespace YYG.IRepository
{
   public interface ISellerRepository: IBaseRepository<SellerEntity>
    {
        void TransactionTest3();

        void DynamicCondition();
    }
}
