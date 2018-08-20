namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        HorsePower = c.String(),
                        PlateNumber = c.String(),
                        Brand_BrandID = c.Int(),
                        Model_ModelID = c.Int(),
                        Owner_OwnerID = c.Int(),
                        ProductionYear_ProductionYearID = c.Int(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandID)
                .ForeignKey("dbo.Models", t => t.Model_ModelID)
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerID)
                .ForeignKey("dbo.ProductionYears", t => t.ProductionYear_ProductionYearID)
                .Index(t => t.Brand_BrandID)
                .Index(t => t.Model_ModelID)
                .Index(t => t.Owner_OwnerID)
                .Index(t => t.ProductionYear_ProductionYearID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand_BrandID = c.Int(),
                    })
                .PrimaryKey(t => t.ModelID)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandID)
                .Index(t => t.Brand_BrandID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            CreateTable(
                "dbo.ProductionYears",
                c => new
                    {
                        ProductionYearID = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.ProductionYearID);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        RepairID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsInactive = c.String(),
                        DateRepair = c.DateTime(),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepairID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PriceHurt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceDetal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        SupplyDate = c.DateTime(nullable: false),
                        PartBrand_PartBrandID = c.Int(),
                        PartCategory_PartCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.PartID)
                .ForeignKey("dbo.PartBrands", t => t.PartBrand_PartBrandID)
                .ForeignKey("dbo.PartCategories", t => t.PartCategory_PartCategoryID)
                .Index(t => t.PartBrand_PartBrandID)
                .Index(t => t.PartCategory_PartCategoryID);
            
            CreateTable(
                "dbo.PartBrands",
                c => new
                    {
                        PartBrandID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PartBrandID);
            
            CreateTable(
                "dbo.PartCategories",
                c => new
                    {
                        PartCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PartCategoryID);
            
            CreateTable(
                "dbo.RepairNotes",
                c => new
                    {
                        RepairNotesID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsInactive = c.String(),
                        Repair_RepairID = c.Int(),
                    })
                .PrimaryKey(t => t.RepairNotesID)
                .ForeignKey("dbo.Repairs", t => t.Repair_RepairID)
                .Index(t => t.Repair_RepairID);
            
            CreateTable(
                "dbo.PartRepairs",
                c => new
                    {
                        Part_PartID = c.Int(nullable: false),
                        Repair_RepairID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Part_PartID, t.Repair_RepairID })
                .ForeignKey("dbo.Parts", t => t.Part_PartID, cascadeDelete: true)
                .ForeignKey("dbo.Repairs", t => t.Repair_RepairID, cascadeDelete: true)
                .Index(t => t.Part_PartID)
                .Index(t => t.Repair_RepairID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairNotes", "Repair_RepairID", "dbo.Repairs");
            DropForeignKey("dbo.PartRepairs", "Repair_RepairID", "dbo.Repairs");
            DropForeignKey("dbo.PartRepairs", "Part_PartID", "dbo.Parts");
            DropForeignKey("dbo.Parts", "PartCategory_PartCategoryID", "dbo.PartCategories");
            DropForeignKey("dbo.Parts", "PartBrand_PartBrandID", "dbo.PartBrands");
            DropForeignKey("dbo.Repairs", "CarID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "ProductionYear_ProductionYearID", "dbo.ProductionYears");
            DropForeignKey("dbo.Cars", "Owner_OwnerID", "dbo.Owners");
            DropForeignKey("dbo.Cars", "Model_ModelID", "dbo.Models");
            DropForeignKey("dbo.Models", "Brand_BrandID", "dbo.Brands");
            DropForeignKey("dbo.Cars", "Brand_BrandID", "dbo.Brands");
            DropIndex("dbo.PartRepairs", new[] { "Repair_RepairID" });
            DropIndex("dbo.PartRepairs", new[] { "Part_PartID" });
            DropIndex("dbo.RepairNotes", new[] { "Repair_RepairID" });
            DropIndex("dbo.Parts", new[] { "PartCategory_PartCategoryID" });
            DropIndex("dbo.Parts", new[] { "PartBrand_PartBrandID" });
            DropIndex("dbo.Repairs", new[] { "CarID" });
            DropIndex("dbo.Models", new[] { "Brand_BrandID" });
            DropIndex("dbo.Cars", new[] { "ProductionYear_ProductionYearID" });
            DropIndex("dbo.Cars", new[] { "Owner_OwnerID" });
            DropIndex("dbo.Cars", new[] { "Model_ModelID" });
            DropIndex("dbo.Cars", new[] { "Brand_BrandID" });
            DropTable("dbo.PartRepairs");
            DropTable("dbo.RepairNotes");
            DropTable("dbo.PartCategories");
            DropTable("dbo.PartBrands");
            DropTable("dbo.Parts");
            DropTable("dbo.Repairs");
            DropTable("dbo.ProductionYears");
            DropTable("dbo.Owners");
            DropTable("dbo.Models");
            DropTable("dbo.Cars");
            DropTable("dbo.Brands");
        }
    }
}
