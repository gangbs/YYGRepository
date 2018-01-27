using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Entity;
using YYG.IRepository;

namespace YYG.Repository
{
   public class VehicleRegistRepository:BaseRepository<VehicleRegistEntity>, IVehicleRegistRepository
    {
        public VehicleRegistRepository(DbContext context):base(context)
        {
        }

        public Tuple<VehicleRegistEntity, VehicleInfoEntity, VehicleLicenseEntity> Test2()
        {
            var infoSet= this.context.Set<VehicleInfoEntity>();
            var licSet = this.context.Set<VehicleLicenseEntity>();

            var reg = from r in this.dbSet
                      join info in infoSet on r.ElectricID equals info.ElectricID
                      join lic in licSet on r.ElectricID equals lic.ElectricID
                      where r.ElectricID == 282
                      select new { Reg = r, Info = info, Lic = lic };


            var aa = reg.AsNoTracking().FirstOrDefault();

            var tt = new Tuple<VehicleRegistEntity, VehicleInfoEntity, VehicleLicenseEntity>(aa?.Reg, aa?.Info, aa?.Lic);
            return tt;


            //var reg = from r in this.dbSet
            //          join info in infoSet on r.ElectricID equals info.ElectricID
            //          join lic in licSet on r.ElectricID equals lic.ElectricID
            //          where r.ElectricID == 282
            //          select new { Reg = r, Info = info, Lic = lic };
            //reg.Where(x=>x.Info.)


        }

        public Tuple<VehicleRegistEntity, VehicleInfoEntity, VehicleLicenseEntity> Test()
        {

            //var a= this.dbSet.Include(reg => reg.Info).Include(reg => reg.License).Where(x => x.ElectricID == 204);

            var infoSet = this.context.Set<VehicleInfoEntity>();
           var a= infoSet.Include(m => m.Regist).Where(x => x.ElectricID == 204); ;

            return null;
        }
    }
}
