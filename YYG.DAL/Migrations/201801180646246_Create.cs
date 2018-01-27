namespace YYG.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_police_info",
                c => new
                    {
                        PoliceID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        UserName = c.String(maxLength: 20, storeType: "nvarchar"),
                        UserRole = c.Int(nullable: false),
                        CardID = c.String(maxLength: 20, storeType: "nvarchar"),
                        Name = c.String(maxLength: 20, storeType: "nvarchar"),
                        AreaCode = c.String(maxLength: 20, storeType: "nvarchar"),
                        PoliceCode = c.String(maxLength: 20, storeType: "nvarchar"),
                        Telephone = c.String(maxLength: 20, storeType: "nvarchar"),
                        HomePlace = c.String(maxLength: 200, storeType: "nvarchar"),
                        Address = c.String(maxLength: 200, storeType: "nvarchar"),
                        Mail = c.String(maxLength: 20, storeType: "nvarchar"),
                        Remark = c.String(maxLength: 20, storeType: "nvarchar"),
                        ValidFlag = c.Int(nullable: false),
                        OperatorID = c.Int(nullable: false),
                        OperateTime = c.DateTime(nullable: false, precision: 0),
                        CreatorID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.PoliceID);
            
            CreateTable(
                "dbo.t_seller",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        UserName = c.String(maxLength: 20, storeType: "nvarchar"),
                        UserRole = c.Int(nullable: false),
                        ShopName = c.String(maxLength: 20, storeType: "nvarchar"),
                        ShopAddress = c.String(maxLength: 20, storeType: "nvarchar"),
                        BusinessNo = c.String(maxLength: 20, storeType: "nvarchar"),
                        Phone = c.String(maxLength: 20, storeType: "nvarchar"),
                        LNG = c.String(maxLength: 20, storeType: "nvarchar"),
                        LAT = c.String(maxLength: 20, storeType: "nvarchar"),
                        OwerName = c.String(maxLength: 20, storeType: "nvarchar"),
                        SellerCardID = c.String(maxLength: 20, storeType: "nvarchar"),
                        Remark = c.String(maxLength: 200, storeType: "nvarchar"),
                        OperatorID = c.Int(nullable: false),
                        OperatorTime = c.DateTime(nullable: false, precision: 0),
                        AreaCode = c.String(maxLength: 20, storeType: "nvarchar"),
                        ValidFlag = c.Int(nullable: false),
                        CreatorID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.SellerID);
            
            CreateTable(
                "dbo.t_seller_brand",
                c => new
                    {
                        RelationID = c.Int(nullable: false, identity: true),
                        SellerID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelationID)
                .ForeignKey("dbo.t_seller", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.SellerID);
            
            CreateTable(
                "dbo.t_vehicle_info",
                c => new
                    {
                        ElectricInfoID = c.Int(nullable: false, identity: true),
                        ElectricID = c.Int(nullable: false),
                        VehicleKind = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        VehicleModel = c.String(maxLength: 20, storeType: "nvarchar"),
                        VehicleType = c.Int(nullable: false),
                        MainColor = c.Int(nullable: false),
                        SecondaryColor = c.Int(nullable: false),
                        EngineNo = c.String(maxLength: 20, storeType: "nvarchar"),
                        FrameNo = c.String(maxLength: 20, storeType: "nvarchar"),
                        Weight = c.Double(nullable: false),
                        SpeedMax = c.Int(nullable: false),
                        BuyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyDate = c.DateTime(nullable: false, precision: 0),
                        ValidFlag = c.Int(nullable: false),
                        OperatorID = c.Int(nullable: false),
                        OperatorTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ElectricInfoID)
                .ForeignKey("dbo.t_vehicle_regist", t => t.ElectricID, cascadeDelete: true)
                .Index(t => t.ElectricID);
            
            CreateTable(
                "dbo.t_vehicle_regist",
                c => new
                    {
                        ElectricID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Int(nullable: false),
                        ValidFlag = c.Int(nullable: false),
                        CreateID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        AreaCode = c.String(maxLength: 20, storeType: "nvarchar"),
                        OperatorID = c.Int(nullable: false),
                        OperatorTime = c.DateTime(nullable: false, precision: 0),
                        Reason = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ElectricID)
                .ForeignKey("dbo.t_vehicle_owner", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.t_vehicle_owner",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(maxLength: 20, storeType: "nvarchar"),
                        CardType = c.Int(nullable: false),
                        CardID = c.String(maxLength: 20, storeType: "nvarchar"),
                        Address = c.String(maxLength: 200, storeType: "nvarchar"),
                        Phone = c.String(maxLength: 20, storeType: "nvarchar"),
                        SecondPhone = c.String(maxLength: 20, storeType: "nvarchar"),
                        OperatorID = c.Int(nullable: false),
                        OperatorTime = c.DateTime(nullable: false, precision: 0),
                        Remark = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            CreateTable(
                "dbo.t_vehicle_license",
                c => new
                    {
                        RelationID = c.Int(nullable: false, identity: true),
                        ElectricID = c.Int(nullable: false),
                        CarNo = c.String(maxLength: 20, storeType: "nvarchar"),
                        CarRFID = c.String(maxLength: 20, storeType: "nvarchar"),
                        PowerRFID = c.String(maxLength: 20, storeType: "nvarchar"),
                        ViceRFID1 = c.String(maxLength: 20, storeType: "nvarchar"),
                        ViceRFID2 = c.String(maxLength: 20, storeType: "nvarchar"),
                        ViceRFID3 = c.String(maxLength: 20, storeType: "nvarchar"),
                        ViceRFID4 = c.String(maxLength: 20, storeType: "nvarchar"),
                        ViceRFID5 = c.String(maxLength: 20, storeType: "nvarchar"),
                        ViceRFID6 = c.String(maxLength: 20, storeType: "nvarchar"),
                        ValidFlag = c.Int(nullable: false),
                        OperatorID = c.Int(nullable: false),
                        OperatorTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.RelationID)
                .ForeignKey("dbo.t_vehicle_regist", t => t.ElectricID, cascadeDelete: true)
                .Index(t => t.ElectricID);
            
            CreateTable(
                "dbo.t_vehicle_transfer",
                c => new
                    {
                        TransferID = c.Int(nullable: false, identity: true),
                        ElectricID = c.Int(nullable: false),
                        OwerOriginID = c.Int(nullable: false),
                        OwerCurrID = c.Int(nullable: false),
                        Reason = c.String(maxLength: 200, storeType: "nvarchar"),
                        OperatorID = c.Int(nullable: false),
                        OperatorTime = c.DateTime(nullable: false, precision: 0),
                        AreaCode = c.String(maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.TransferID)
                .ForeignKey("dbo.t_vehicle_owner", t => t.OwerCurrID, cascadeDelete: true)
                .ForeignKey("dbo.t_vehicle_owner", t => t.OwerOriginID, cascadeDelete: true)
                .ForeignKey("dbo.t_vehicle_regist", t => t.ElectricID, cascadeDelete: true)
                .Index(t => t.ElectricID)
                .Index(t => t.OwerOriginID)
                .Index(t => t.OwerCurrID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_vehicle_transfer", "ElectricID", "dbo.t_vehicle_regist");
            DropForeignKey("dbo.t_vehicle_transfer", "OwerOriginID", "dbo.t_vehicle_owner");
            DropForeignKey("dbo.t_vehicle_transfer", "OwerCurrID", "dbo.t_vehicle_owner");
            DropForeignKey("dbo.t_vehicle_license", "ElectricID", "dbo.t_vehicle_regist");
            DropForeignKey("dbo.t_vehicle_info", "ElectricID", "dbo.t_vehicle_regist");
            DropForeignKey("dbo.t_vehicle_regist", "OwnerID", "dbo.t_vehicle_owner");
            DropForeignKey("dbo.t_seller_brand", "SellerID", "dbo.t_seller");
            DropIndex("dbo.t_vehicle_transfer", new[] { "OwerCurrID" });
            DropIndex("dbo.t_vehicle_transfer", new[] { "OwerOriginID" });
            DropIndex("dbo.t_vehicle_transfer", new[] { "ElectricID" });
            DropIndex("dbo.t_vehicle_license", new[] { "ElectricID" });
            DropIndex("dbo.t_vehicle_regist", new[] { "OwnerID" });
            DropIndex("dbo.t_vehicle_info", new[] { "ElectricID" });
            DropIndex("dbo.t_seller_brand", new[] { "SellerID" });
            DropTable("dbo.t_vehicle_transfer");
            DropTable("dbo.t_vehicle_license");
            DropTable("dbo.t_vehicle_owner");
            DropTable("dbo.t_vehicle_regist");
            DropTable("dbo.t_vehicle_info");
            DropTable("dbo.t_seller_brand");
            DropTable("dbo.t_seller");
            DropTable("dbo.t_police_info");
        }
    }
}
