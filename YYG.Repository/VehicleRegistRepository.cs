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

        public IEnumerable<Tuple< VehicleInfoEntity,VehicleRegistEntity>> Test()
        {
            var infoSet = this.context.Set<VehicleInfoEntity>();           
            //var exp = this.dbSet.Join(infoSet, x => x.ElectricID, y => y.ElectricID, (x, y) => new { reg = x, info = y }).Where(x => x.reg.ElectricID == 1);


            //var b = exp.AsNoTracking().ToList();
            //return null;

            var reg = (from r in this.dbSet
                      join info in infoSet on r.ElectricID equals info.ElectricID
                      select new { Reg = r, Info = info}).Where(x => x.Reg.ElectricID == 1).AsNoTracking().ToList();
           var st= this.context.Entry(reg[0].Info).State;

            return null;
        }

        public void IncludeTest()
        {
            var a = this.dbSet.Include(m => m.Info).Include(m => m.License).Where(x => x.ElectricID == 1).ToList();
        }
    }
}
