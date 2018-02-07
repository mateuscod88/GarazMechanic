using DB.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class CarHistoryContext : DbContext
    {

        public CarHistoryContext() : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarHistoryContext, DB.Migrations.Configuration>());

        }
        public DbSet<Car> Cars { get; set;}
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models{ get; set; }
        public DbSet<Owner> Owners{ get; set; }
        public DbSet<Part> Parts{ get; set; }
        public DbSet<Repair> Repairs { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Repair>()
                        .HasMany<Part>(s => s.Parts)
                        .WithMany(c => c.Repairs)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("RepairRefId");
                            cs.MapRightKey("PartRefId");
                            cs.ToTable("UsedPart");
                        });

        }


    }
}
