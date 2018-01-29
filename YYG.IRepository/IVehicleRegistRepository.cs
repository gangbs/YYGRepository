using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYG.DTO;
using YYG.Entity;

namespace YYG.IRepository
{
   public interface IVehicleRegistRepository : IBaseRepository<VehicleRegistEntity>
    {
        IEnumerable<VehicleInfoDto> GetInfoList(Expression<Func<VehicleInfoDto, bool>> filter, int pageSize, int pageNum, out int count);
    }
}
