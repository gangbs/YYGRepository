using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Entity;

namespace YYG.DAL
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]//使用程序自定义的配置
    public class MyDBContext : DbContext
    {
        //static MyDBContext()
        //{
        //    //关闭数据库初始化
        //    Database.SetInitializer<MyDBContext>(null);
        //}

        //用webConfig中的配置来连接数据库
        public MyDBContext() : base("MyConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// 用连接字符串来连接
        /// </summary>
        /// <param name="conStr"></param>
        //public MyDBContext(string conStr) : base(conStr)
        //{
        //    //如果不是sqlserver则需修改context.Database.DefaultConnectionFactory的内容

        //}

        //用DbConnection对象来创建数据库上下文，DbConnection可根据连接字符串和提供程序名来生成
        //public MyDBContext(DbConnection con) : base(con, true)
        //{
        //    // 禁用延迟加载（也可称作懒惰加载）           
        //    this.Configuration.LazyLoadingEnabled = false;//懒惰加载的使用需要：1.有导航属性，2.导航属性被virtual所修饰
        //    //在关闭懒惰加载时，也可以通过使用显示加载来达到相同的懒惰加载的效果
        //}

        public DbSet<SellerEntity> Seller { get; set; }
        public DbSet<PoliceEnity> PoliceInfo { get; set; }
        public DbSet<SellerBrandEntity> SellerBrand { get; set; }
        public DbSet<VehicleInfoEntity> VehicleInfo { get; set; }
        public DbSet<VehicleOwnerEntity> VehicleOwner { get; set; }
        public DbSet<VehicleLicenseEntity> VehicleLicense { get; set; }
        public DbSet<VehicleRegistEntity> VehicleRegist { get; set; }
        public DbSet<VehicleTransferEntity> VehicleTransfer { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//指定单数形式的表名(默认复数形式)
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDBContext, Migrations.Configuration>());//自动更新数据库,省去了update-database命令

            //modelBuilder.HasDefaultSchema("");

            //modelBuilder.Entity<VehicleRegistEntity>().HasRequired(m => m.Owner).WithMany(m => m.Regist).HasForeignKey(m => m.OwnerID);
            //modelBuilder.Entity<VehicleInfoEntity>().HasRequired(m => m.Regist).WithMany(m => m.in).HasForeignKey(m => m.OwnerID);

        }
    }
}
