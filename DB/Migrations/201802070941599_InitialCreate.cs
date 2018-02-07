namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand_BrandID = c.Int(),
                        Model_ModelID = c.Int(),
                        Owner_OwnerID = c.Int(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandID)
                .ForeignKey("dbo.Models", t => t.Model_ModelID)
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerID)
                .Index(t => t.Brand_BrandID)
                .Index(t => t.Model_ModelID)
                .Index(t => t.Owner_OwnerID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ModelID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        RepairID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.RepairID)
                .ForeignKey("dbo.Cars", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PartID);
            
            CreateTable(
                "dbo.UsedPart",
                c => new
                    {
                        RepairRefId = c.Int(nullable: false),
                        PartRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RepairRefId, t.PartRefId })
                .ForeignKey("dbo.Repairs", t => t.RepairRefId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartRefId, cascadeDelete: true)
                .Index(t => t.RepairRefId)
                .Index(t => t.PartRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsedPart", "PartRefId", "dbo.Parts");
            DropForeignKey("dbo.UsedPart", "RepairRefId", "dbo.Repairs");
            DropForeignKey("dbo.Repairs", "Car_CarID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "Owner_OwnerID", "dbo.Owners");
            DropForeignKey("dbo.Cars", "Model_ModelID", "dbo.Models");
            DropForeignKey("dbo.Cars", "Brand_BrandID", "dbo.Brands");
            DropIndex("dbo.UsedPart", new[] { "PartRefId" });
            DropIndex("dbo.UsedPart", new[] { "RepairRefId" });
            DropIndex("dbo.Repairs", new[] { "Car_CarID" });
            DropIndex("dbo.Cars", new[] { "Owner_OwnerID" });
            DropIndex("dbo.Cars", new[] { "Model_ModelID" });
            DropIndex("dbo.Cars", new[] { "Brand_BrandID" });
            DropTable("dbo.UsedPart");
            DropTable("dbo.Parts");
            DropTable("dbo.Repairs");
            DropTable("dbo.Owners");
            DropTable("dbo.Models");
            DropTable("dbo.Cars");
            DropTable("dbo.Brands");
        }
    }
}
