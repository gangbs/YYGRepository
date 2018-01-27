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
   public class VehicleOwnerRepository : BaseRepository<VehicleOwnerEntity>, IVehicleOwnerRepository
    {
        public VehicleOwnerRepository(DbContext context):base(context)
        {
        }
    }
}
