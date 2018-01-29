using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYG.DTO;
using YYG.Entity;
using YYG.IRepository;

namespace YYG.Repository
{
   public class VehicleRegistRepository:BaseRepository<VehicleRegistEntity>, IVehicleRegistRepository
    {
        public VehicleRegistRepository(DbContext context):base(context)
        {
        }

        public IEnumerable<VehicleInfoDto> GetInfoList(Expression<Func<VehicleInfoDto, bool>> filter, int pageSize, int pageNum, out int count)
        {
            var linq = from reg in this.dbSet
                            join info in this.context.Set<VehicleInfoEntity>() on reg.ElectricID equals info.ElectricID
                            join lic in this.context.Set<VehicleLicenseEntity>() on reg.ElectricID equals lic.ElectricID                            
                            select new VehicleInfoDto
                            {
                                ElectricID = reg.ElectricID,
                                CreateTime = reg.CreateTime,

                                AreaCode = reg.AreaCode,
                                BrandID = info.BrandID,
                                BuyDate = info.BuyDate,
                                BuyPrice = info.BuyPrice,
                                CarNo = lic.CarNo,
                                CarRFID = lic.CarRFID,
                                CreateID = reg.CreateID,
                                EngineNo = info.EngineNo,
                                FrameNo = info.FrameNo,
                                MainColor = info.MainColor,
                                PowerRFID = lic.PowerRFID,
                                SecondaryColor = info.SecondaryColor,
                                SpeedMax = info.SpeedMax,
                                VehicleKind = info.VehicleKind,
                                VehicleModel = info.VehicleModel,
                                VehicleType = info.VehicleType,
                                Weight = info.Weight
                            };
            count = linq.Where(filter).AsNoTracking().Count();
            var lst=linq.Where(filter).OrderBy(x=>x.ElectricID).Skip(pageSize * (pageNum - 1)).Take(pageSize).AsNoTracking();
            return lst.ToList();
        }
    }
}
