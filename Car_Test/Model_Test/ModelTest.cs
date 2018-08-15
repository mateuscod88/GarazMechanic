using AutoFixture;
using BL.Model.Service;
using DB.Domain;
using DB.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Test.Model_Test
{
    class ModelTest
    {
        private Mock<DbSet<Model>> modelMock;

        [SetUp]
        public void Setup()
        {
            Fixture fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var models = new List<Model>
                      {
                        fixture.Build<Model>().With(u => u.ModelID, 1).With(u => u.Brand,fixture.Build<Brand>().With(u => u.BrandID, 1).With(u => u.Name,"Audi").Create()).With(u => u.Name,"A4").Create(),
                        fixture.Build<Model>().With(u => u.ModelID, 2).With(u => u.Brand,fixture.Build<Brand>().With(u => u.BrandID, 2).With(u => u.Name,"Vw").Create()).With(u => u.Name,"PASSAT").Create(),
                        fixture.Build<Model>().With(u => u.ModelID, 3).With(u => u.Brand,fixture.Build<Brand>().With(u => u.BrandID, 3).With(u => u.Name,"Skoda").Create()).With(u => u.Name,"OCTAVIA").Create(),
                        fixture.Build<Model>().With(u => u.ModelID, 4).With(u => u.Brand,fixture.Build<Brand>().With(u => u.BrandID, 1).With(u => u.Name,"Audi").Create()).With(u => u.Name,"A6").Create(),
                        fixture.Build<Model>().With(u => u.ModelID, 5).With(u => u.Brand,fixture.Build<Brand>().With(u => u.BrandID, 2).With(u => u.Name,"Vw").Create()).With(u => u.Name,"GOLF").Create(),
                        fixture.Build<Model>().With(u => u.ModelID, 6).With(u => u.Brand,fixture.Build<Brand>().With(u => u.BrandID, 3).With(u => u.Name,"Skoda").Create()).With(u => u.Name,"SuperB").Create()
                      }.AsQueryable();
            modelMock= new Mock<DbSet<Model>>();
            modelMock.As<IQueryable<Model>>().Setup(m => m.Provider).Returns(models.Provider);
            modelMock.As<IQueryable<Model>>().Setup(m => m.Expression).Returns(models.Expression);
            modelMock.As<IQueryable<Model>>().Setup(m => m.ElementType).Returns(models.ElementType);
            modelMock.As<IQueryable<Model>>().Setup(m => m.GetEnumerator()).Returns(models.GetEnumerator());
        }
      
        [Test]
        public void Get_All_Models_By_Brand_Id()
        {
            var modelContextMock = new Mock<IDatabaseService>();
            modelContextMock.Setup(m => m.Models).Returns(modelMock.Object);

            var modelService = new ModelService(modelContextMock.Object);
            var models = modelService.GetAllModelsByBrandId(1);

            Assert.IsTrue(models.Count == 2);
        }
        [Test]
        public void Get_Model_By_Id()
        {
            var modelContextMock = new Mock<IDatabaseService>();
            modelContextMock.Setup(m => m.Models).Returns(modelMock.Object);

            var modelService = new ModelService(modelContextMock.Object);
            var model = modelService.GetModelById(1);
            Assert.IsTrue(model.Name == "A4");
        }
    }
}
