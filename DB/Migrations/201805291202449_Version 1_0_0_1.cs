namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1_0_0_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Brand_BrandID", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_BrandID" });
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
            
            AddColumn("dbo.Models", "Brand_BrandID", c => c.Int());
            AddColumn("dbo.Parts", "PriceHurt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Parts", "PriceDetal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Parts", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Parts", "SupplyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parts", "PartBrand_PartBrandID", c => c.Int());
            AddColumn("dbo.Parts", "PartCategory_PartCategoryID", c => c.Int());
            CreateIndex("dbo.Models", "Brand_BrandID");
            CreateIndex("dbo.Parts", "PartBrand_PartBrandID");
            CreateIndex("dbo.Parts", "PartCategory_PartCategoryID");
            AddForeignKey("dbo.Models", "Brand_BrandID", "dbo.Brands", "BrandID");
            AddForeignKey("dbo.Parts", "PartBrand_PartBrandID", "dbo.PartBrands", "PartBrandID");
            AddForeignKey("dbo.Parts", "PartCategory_PartCategoryID", "dbo.PartCategories", "PartCategoryID");
            DropColumn("dbo.Cars", "Brand_BrandID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Brand_BrandID", c => c.Int());
            DropForeignKey("dbo.Parts", "PartCategory_PartCategoryID", "dbo.PartCategories");
            DropForeignKey("dbo.Parts", "PartBrand_PartBrandID", "dbo.PartBrands");
            DropForeignKey("dbo.Models", "Brand_BrandID", "dbo.Brands");
            DropIndex("dbo.Parts", new[] { "PartCategory_PartCategoryID" });
            DropIndex("dbo.Parts", new[] { "PartBrand_PartBrandID" });
            DropIndex("dbo.Models", new[] { "Brand_BrandID" });
            DropColumn("dbo.Parts", "PartCategory_PartCategoryID");
            DropColumn("dbo.Parts", "PartBrand_PartBrandID");
            DropColumn("dbo.Parts", "SupplyDate");
            DropColumn("dbo.Parts", "Quantity");
            DropColumn("dbo.Parts", "PriceDetal");
            DropColumn("dbo.Parts", "PriceHurt");
            DropColumn("dbo.Models", "Brand_BrandID");
            DropTable("dbo.PartCategories");
            DropTable("dbo.PartBrands");
            CreateIndex("dbo.Cars", "Brand_BrandID");
            AddForeignKey("dbo.Cars", "Brand_BrandID", "dbo.Brands", "BrandID");
        }
    }
}
