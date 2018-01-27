using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Entity;
using YYG.IRepository;

namespace YYG.Repository
{
   public class VehicleInfoRepository : BaseRepository<VehicleInfoEntity>, IVehicleInfoRepository
    {
        public VehicleInfoRepository(DbContext context):base(context)
        {
        }
    }
}
