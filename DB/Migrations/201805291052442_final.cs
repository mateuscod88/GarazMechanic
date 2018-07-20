namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsedPart", newName: "PartRepairs");
            RenameColumn(table: "dbo.PartRepairs", name: "RepairRefId", newName: "Repair_RepairID");
            RenameColumn(table: "dbo.PartRepairs", name: "PartRefId", newName: "Part_PartID");
            RenameIndex(table: "dbo.PartRepairs", name: "IX_PartRefId", newName: "IX_Part_PartID");
            RenameIndex(table: "dbo.PartRepairs", name: "IX_RepairRefId", newName: "IX_Repair_RepairID");
            DropPrimaryKey("dbo.PartRepairs");
            AddPrimaryKey("dbo.PartRepairs", new[] { "Part_PartID", "Repair_RepairID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PartRepairs");
            AddPrimaryKey("dbo.PartRepairs", new[] { "RepairRefId", "PartRefId" });
            RenameIndex(table: "dbo.PartRepairs", name: "IX_Repair_RepairID", newName: "IX_RepairRefId");
            RenameIndex(table: "dbo.PartRepairs", name: "IX_Part_PartID", newName: "IX_PartRefId");
            RenameColumn(table: "dbo.PartRepairs", name: "Part_PartID", newName: "PartRefId");
            RenameColumn(table: "dbo.PartRepairs", name: "Repair_RepairID", newName: "RepairRefId");
            RenameTable(name: "dbo.PartRepairs", newName: "UsedPart");
        }
    }
}
