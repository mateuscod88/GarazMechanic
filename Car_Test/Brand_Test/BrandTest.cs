using AutoFixture;
using DB.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Brand.Service;
using BL.Brand.DTO;


namespace Car_Test.Brand_Test
{
    [TestFixture]
    class BrandTest
    {
        private Mock<DbSet<Brand>> brandMock;

        [SetUp]
        public void Setup()
        {
            Fixture fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var brands = new List<Brand>
                      {
                        fixture.Build<Brand>().With(u => u.BrandID, 1).With(u => u.Name,"Audi").Create(),
                        fixture.Build<Brand>().With(u => u.BrandID, 2).With(u => u.Name,"Vw").Create(),
                        fixture.Build<Brand>().With(u => u.BrandID, 3).With(u => u.Name,"Skoda").Create()
                      }.AsQueryable();
            brandMock = new Mock<DbSet<Brand>>();
            brandMock.As<IQueryable<Brand>>().Setup(m => m.Provider).Returns(brands.Provider);
            brandMock.As<IQueryable<Brand>>().Setup(m => m.Expression).Returns(brands.Expression);
            brandMock.As<IQueryable<Brand>>().Setup(m => m.ElementType).Returns(brands.ElementType);
            brandMock.As<IQueryable<Brand>>().Setup(m => m.GetEnumerator()).Returns(brands.GetEnumerator());


        }

        [Test]
        public void Get_All_Brands() { 

            var brandContextMock = new Mock<DB.Interface.IDatabaseService>();
            brandContextMock.Setup(x => x.Brands).Returns(brandMock.Object);

            BrandService brandService = new BrandService(brandContextMock.Object);
            var allBrands = brandService.GetAllBrands();

            Assert.IsTrue(allBrands.Count == 3);
        }
        [Test]
        public void Get_Brand_By_Id()
        {
            var brandContextMock = new Mock<DB.Interface.IDatabaseService>();
            brandContextMock.Setup(x => x.Brands).Returns(brandMock.Object);
            BrandService brandService = new BrandService(brandContextMock.Object);
            var brand = brandService.GetBrandById(1);

            Assert.IsTrue(brand.ID == 1);

        }
    }
}
