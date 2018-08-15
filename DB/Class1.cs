using DB.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interface;
namespace DB
{
    public class CarHistoryContext : DbContext , IDatabaseService
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<PartBrand> PartBrands { get; set; }
        public DbSet<PartCategory> PartCategory { get; set; }
        public DbSet<ProductionYear> ProductionYear{ get; set; }
        public DbSet<RepairNotes> RepairNotes { get; set; }

        public CarHistoryContext() : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarHistoryContext, DB.Migrations.Configuration>());

        }
        
        public void Save()
        {
            
            this.SaveChanges();
        }
        public void Update(object entity,object newEntity)
        {
            this.Entry(entity).CurrentValues.SetValues(newEntity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            

        }
        

    }
}
