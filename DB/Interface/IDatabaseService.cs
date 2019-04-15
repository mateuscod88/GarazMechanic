using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DB.Domain;
namespace DB.Interface
{
        public interface IDatabaseService : IDisposable
        {
         DbSet<Car> Cars { get; set; }
         DbSet<Brand> Brands { get; set; }
         DbSet<Model> Models { get; set; }
         DbSet<Engine> Engines { get; set; }
         DbSet<Owner> Owners { get; set; }
         DbSet<Part> Parts { get; set; }
         DbSet<Repair> Repairs { get; set; }
         DbSet<PartBrand> PartBrands { get; set; }
         DbSet<PartCategory> PartCategory { get; set; }
         DbSet<ProductionYear> ProductionYear { get; set; }
         DbSet<RepairNotes> RepairNotes { get; set; }
         void Save();
         void Update(object entity, object newEntity);

    }

}
