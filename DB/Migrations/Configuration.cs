namespace DB.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DB.CarHistoryContext>
    {
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = true ;
            ContextKey = "DB.CarHistoryContext";
        }

        protected override void Seed(DB.CarHistoryContext context)
        {
            const int year = 1990;
            for (int i = 0; i < 30; i++)
            {
                context.ProductionYear.Add(new Domain.ProductionYear { Year = (year + i).ToString() });

            }
            context.SaveChanges();

            context.Brands.Add(new Domain.Brand { Name = "AUDI" });
            context.Brands.Add(new Domain.Brand { Name = "BMW" });
            context.Brands.Add(new Domain.Brand { Name = "VW" });
            context.Brands.Add(new Domain.Brand { Name = "SKODA" });
            context.Brands.Add(new Domain.Brand { Name = "OPEL" });
            context.Brands.Add(new Domain.Brand { Name = "HONDA" });

            context.SaveChanges();

            var audi = context.Brands
                                 .Where(x => x.Name == "AUDI")
                                 .FirstOrDefault();
            var bmw = context.Brands
                                 .Where(x => x.Name == "BMW")
                                 .FirstOrDefault();
            var vw = context.Brands
                                 .Where(x => x.Name == "VW")
                                 .FirstOrDefault();
            var skoda = context.Brands
                                 .Where(x => x.Name == "SKODA")
                                 .FirstOrDefault();
            var opel = context.Brands
                                 .Where(x => x.Name == "OPEL")
                                 .FirstOrDefault();
            var honda = context.Brands
                                 .Where(x => x.Name == "HONDA")
                                 .FirstOrDefault();


            context.Models.Add(new Domain.Model { Name = "A4", Brand = audi });
            context.Models.Add(new Domain.Model { Name = "A3", Brand = audi });
            context.Models.Add(new Domain.Model { Name = "A5", Brand = audi });
            context.Models.Add(new Domain.Model { Name = "A6", Brand = audi });
            context.SaveChanges();

            context.Models.Add(new Domain.Model { Name = "GOLF", Brand = vw });
            context.Models.Add(new Domain.Model { Name = "PASSAT", Brand = vw });
            context.Models.Add(new Domain.Model { Name = "POLO", Brand = vw });
            context.Models.Add(new Domain.Model { Name = "TOURAN", Brand = vw });
            context.SaveChanges();

            context.Models.Add(new Domain.Model { Name = "3(E46)", Brand = bmw });
            context.Models.Add(new Domain.Model { Name = "5(E66)", Brand = bmw });
            context.Models.Add(new Domain.Model { Name = "7(E99)", Brand = bmw });
            context.Models.Add(new Domain.Model { Name = "1(E11)", Brand = bmw });
            context.SaveChanges();

            context.Models.Add(new Domain.Model { Name = "SUPERB", Brand = skoda });
            context.Models.Add(new Domain.Model { Name = "OCTAVIA", Brand = skoda });
            context.Models.Add(new Domain.Model { Name = "FABIA", Brand = skoda });
            context.Models.Add(new Domain.Model { Name = "RAPID", Brand = skoda });
            context.SaveChanges();

            context.Models.Add(new Domain.Model { Name = "ASTRA", Brand = opel });
            context.Models.Add(new Domain.Model { Name = "VECTRA", Brand = opel });
            context.Models.Add(new Domain.Model { Name = "CORSA", Brand = opel });
            context.SaveChanges();

            context.Models.Add(new Domain.Model { Name = "ACCORD", Brand = honda });
            context.Models.Add(new Domain.Model { Name = "CR-V", Brand = honda });

            context.SaveChanges();

            var volksW = context.Brands.FirstOrDefault(x => x.Name == "VW");
            var vwModel = context.Models.Where(x => x.Brand.BrandID == volksW.BrandID).ToList();

            foreach (var model in vwModel)
            {
                context.Engines.Add(new Domain.Engine { Name = "1.9TDI 110KM",Brand = volksW,Model = model });
                context.Engines.Add(new Domain.Engine { Name = "1.9TDI 115KM",Brand = volksW,Model = model });
                context.Engines.Add(new Domain.Engine { Name = "1.9TDI 130KM",Brand = volksW,Model = model });
                context.Engines.Add(new Domain.Engine { Name = "1.9TDI 90KM", Brand = volksW, Model = model });
            }
            context.SaveChanges();
            

            context.PartBrands.Add(new Domain.PartBrand { Name = "TRW" });
            context.PartBrands.Add(new Domain.PartBrand { Name = "LuK" });
            context.PartBrands.Add(new Domain.PartBrand { Name = "INA" });
            context.PartBrands.Add(new Domain.PartBrand { Name = "Sachs" });
            context.SaveChanges();

            var trw = context.PartBrands
                               .Where(x => x.Name == "TRW")
                               .FirstOrDefault();
            var luk = context.PartBrands
                               .Where(x => x.Name == "LuK")
                               .FirstOrDefault();
            var ina = context.PartBrands
                               .Where(x => x.Name == "INA")
                               .FirstOrDefault();
            var sachs = context.PartBrands
                               .Where(x => x.Name == "Sachs")
                               .FirstOrDefault();
            context.PartCategory.Add(new Domain.PartCategory { Name = "Zawieszenie" });
            context.PartCategory.Add(new Domain.PartCategory { Name = "Rozrzad" });
            context.PartCategory.Add(new Domain.PartCategory { Name = "Sprzeglo" });
            context.PartCategory.Add(new Domain.PartCategory { Name = "Elementy Sprzegla" });
            context.SaveChanges();

            var suspension = context.PartCategory
                                    .Where(x => x.Name == "Zawieszenie")
                                    .FirstOrDefault();
            var timingBelt = context.PartCategory
                                    .Where(x => x.Name == "Rozrzad")
                                    .FirstOrDefault();
            var clutch = context.PartCategory
                                    .Where(x => x.Name == "Sprzeglo")
                                    .FirstOrDefault();
            var clutchPart = context.PartCategory
                                    .Where(x => x.Name == "Elementy Sprzegla")
                                    .FirstOrDefault();

            context.Parts.Add(new Domain.Part { Name = "Wahacz", PartBrand = trw, PartCategory = suspension, SupplyDate = DateTime.Now });
            context.Parts.Add(new Domain.Part { Name = "Zestaw rozrzadu", PartBrand = ina, PartCategory = timingBelt, SupplyDate = DateTime.Now });
            context.Parts.Add(new Domain.Part { Name = "Zestaw sprzegla", PartBrand = luk, PartCategory = clutch, SupplyDate = DateTime.Now });
            context.Parts.Add(new Domain.Part { Name = "Wysprzeglik", PartBrand = sachs, PartCategory = clutchPart, SupplyDate = DateTime.Now });
            context.SaveChanges();

            context.Owners.Add(new Domain.Owner { Name = "Mateusz Kalinowski" });
            context.Owners.Add(new Domain.Owner { Name = "Adam Zalinowski" });
            context.Owners.Add(new Domain.Owner { Name = "Wojciech Palinowski" });
            context.SaveChanges();

            var passat = context.Models
                                .Where(x => x.Name == "PASSAT")
                                .FirstOrDefault();
            var audica = context.Models
                                .Where(x => x.Name == "PASSAT")
                                .FirstOrDefault();
            var mateo = context.Owners
                               .Where(x => x.Name == "Mateusz Kalinowski")
                               .FirstOrDefault();
            var adam = context.Owners
                              .Where(x => x.Name == "Adam Zalinowski")
                              .FirstOrDefault();
            var wojciech = context.Owners
                              .Where(x => x.Name == "Wojciech Palinowski")
                              .FirstOrDefault();
            var year_2000 = context.ProductionYear.Where(y => y.Year == "2000").FirstOrDefault();
            var engineVwPassat = context.Engines.FirstOrDefault(x=> x.Brand.BrandID == vw.BrandID && x.Model.ModelID == passat.ModelID);

            context.Cars.Add(new Domain.Car { Model = passat, Owner = mateo, HorsePower = "130", PlateNumber = "BIA00568", Brand = vw, ProductionYear = year_2000, Engine = engineVwPassat });
            context.Cars.Add(new Domain.Car { Model = passat, Owner = adam, HorsePower = "130", PlateNumber = "BIA00568", Brand = vw, ProductionYear = year_2000, Engine = engineVwPassat });
            context.Cars.Add(new Domain.Car { Model = passat, Owner = mateo, HorsePower = "130", PlateNumber = "BIA00568", Brand = vw, ProductionYear = year_2000, Engine = engineVwPassat });
            context.Cars.Add(new Domain.Car { Model = passat, Owner = wojciech, HorsePower = "130", PlateNumber = "BIA00568", Brand = vw, ProductionYear = year_2000, Engine = engineVwPassat });

            context.SaveChanges();

            var passatMateo = context.Cars
                                     .Where(x => x.Owner.OwnerID == mateo.OwnerID)
                                     .FirstOrDefault();
            var timingBeltComplet = context.Parts
                                           .Where(x => x.Name == "Zestaw rozrzadu")
                                           .FirstOrDefault();
            var timingBeltComplet2 = context.Parts
                                           .Where(x => x.Name == "Zestaw rozrzadu")
                                           .FirstOrDefault();
            var clutchComplete = context.Parts
                                    .Where(x => x.Name == "Zestaw sprzegla")
                                    .FirstOrDefault();

            context.Repairs.Add(new Domain.Repair { CarID = passatMateo.CarID, Name = "Wymiana rozrzadu",DateRepair= DateTime.Now });
            //context.Repairs.Add(new Domain.Repair { Car = passatMateo, Name = "Wymiana sprzegla", RepairDate = DateTime.Parse("25/05/2018"), RepairNotes = null, Parts = new List<Domain.Part>(new Domain.Part[] { clutchComplete }) });

            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
