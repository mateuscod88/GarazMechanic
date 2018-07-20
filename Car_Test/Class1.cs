using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using Moq;
using DB.Domain;
using DB.Interface;
using System.Data.Entity;
using AutoFixture;
using BL.Car.Services;
using BL.Car.DTO;

namespace Car_Test
{
    [TestFixture]
    public class CarCRUD
    {
        private AutoMoqer _automock;
        private Mock<DbSet<Car>> carsMock;
        private Mock<DbSet<Owner>> ownerMock;
        private Mock<DbSet<Model>> modelMock;
        private Mock<DbSet<Brand>> brandMock;
        private Mock<DbSet<ProductionYear>> productionYearsMock;

        [SetUp]
        public void Setup()
        {
            Fixture fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var cars = new List<Car>
                      {
                        fixture.Build<Car>().With(u => u.CarID, 1).With(u => u.Name,"Audi").Create(),
                        fixture.Build<Car>().With(u => u.CarID, 2).With(u => u.Name,"Vw").Create(),
                        fixture.Build<Car>().With(u => u.CarID, 3).With(u => u.Name,"Skoda").Create()
                      }.AsQueryable();

            carsMock = new Mock<DbSet<Car>>();
            carsMock.As<IQueryable<Car>>().Setup(m => m.Provider).Returns(cars.Provider);
            carsMock.As<IQueryable<Car>>().Setup(m => m.Expression).Returns(cars.Expression);
            carsMock.As<IQueryable<Car>>().Setup(m => m.ElementType).Returns(cars.ElementType);
            carsMock.As<IQueryable<Car>>().Setup(m => m.GetEnumerator()).Returns(cars.GetEnumerator());

            var models = new List<Model>
                      {
                        fixture.Build<Model>().With(u => u.Name, "A4").With(u => u.ModelID,1).Create(),
                        fixture.Build<Model>().With(u => u.Name, "A3").With(u => u.ModelID,2).Create(),
                        fixture.Build<Model>().With(u => u.Name, "A6").With(u => u.ModelID,3).Create()
                      }.AsQueryable();

            modelMock = new Mock<DbSet<Model>>();
            modelMock.As<IQueryable<Model>>().Setup(m => m.Provider).Returns(models.Provider);
            modelMock.As<IQueryable<Model>>().Setup(m => m.Expression).Returns(models.Expression);
            modelMock.As<IQueryable<Model>>().Setup(m => m.ElementType).Returns(models.ElementType);
            modelMock.As<IQueryable<Model>>().Setup(m => m.GetEnumerator()).Returns(models.GetEnumerator());

            var productionYears = new List<ProductionYear>
                      {
                        fixture.Build<ProductionYear>().With(u => u.Year, "1999").With(u => u.ProductionYearID,1).Create(),
                        fixture.Build<ProductionYear>().With(u => u.Year, "2002").With(u => u.ProductionYearID,2).Create(),
                        fixture.Build<ProductionYear>().With(u => u.Year, "2004").With(u => u.ProductionYearID,3).Create()
                      }.AsQueryable();

            productionYearsMock = new Mock<DbSet<ProductionYear>>();
            productionYearsMock.As<IQueryable<ProductionYear>>().Setup(m => m.Provider).Returns(productionYears.Provider);
            productionYearsMock.As<IQueryable<ProductionYear>>().Setup(m => m.Expression).Returns(productionYears.Expression);
            productionYearsMock.As<IQueryable<ProductionYear>>().Setup(m => m.ElementType).Returns(productionYears.ElementType);
            productionYearsMock.As<IQueryable<ProductionYear>>().Setup(m => m.GetEnumerator()).Returns(productionYears.GetEnumerator());

            var owners = new List<Owner>
                      {
                        fixture.Build<Owner>().With(u => u.Name,"Wojtek").With(u => u.OwnerID,1).Create(),
                        fixture.Build<Owner>().With(u => u.Name,"Wojtek").With(u => u.OwnerID,2).Create(),
                        fixture.Build<Owner>().With(u => u.Name,"Wojtek").With(u => u.OwnerID,3).Create()
                      }.AsQueryable();

            ownerMock = new Mock<DbSet<Owner>>();
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.Provider).Returns(owners.Provider);
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.Expression).Returns(owners.Expression);
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.ElementType).Returns(owners.ElementType);
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.GetEnumerator()).Returns(owners.GetEnumerator());


            var brands = new List<Brand>
                      {
                        fixture.Build<Brand>().With(u => u.Name,"Audi").With(u => u.BrandID,1).Create(),
                        fixture.Build<Brand>().With(u => u.Name,"Vw").With(u => u.BrandID,2).Create(),
                        fixture.Build<Brand>().With(u => u.Name,"Skoda").With(u => u.BrandID,3).Create()
                      }.AsQueryable();

            brandMock = new Mock<DbSet<Brand>>();
            brandMock.As<IQueryable<Brand>>().Setup(m => m.Provider).Returns(brands.Provider);
            brandMock.As<IQueryable<Brand>>().Setup(m => m.Expression).Returns(brands.Expression);
            brandMock.As<IQueryable<Brand>>().Setup(m => m.ElementType).Returns(brands.ElementType);
            brandMock.As<IQueryable<Brand>>().Setup(m => m.GetEnumerator()).Returns(brands.GetEnumerator());


        }
        [Test]
        public void Read_All_Cars()
        {

            
            var carContextMock = new Mock<DB.Interface.IDatabaseService>();
            carContextMock.Setup(x => x.Cars).Returns(carsMock.Object);


            var allCarsQuery = new GetAllCarQuery(carContextMock.Object);
            var allCars = allCarsQuery.Execute();
            Assert.IsTrue(allCars.Count > 0);
        }
        [Test]
        public void Read_Car_By_Id()
        {
            var id = 2;
            var carContextMock = new Mock<DB.Interface.IDatabaseService>();
            carContextMock.Setup(x => x.Cars).Returns(carsMock.Object);

            var query = new GetCarById(carContextMock.Object);
            var car = query.Execute(id);

            Assert.AreEqual(car.Id, id);

        }
        [Test]
        public void Add_Car()
        {
            
            var carContextMock = new Mock<DB.Interface.IDatabaseService>();
            carContextMock.Setup(x => x.Cars).Returns(carsMock.Object);
            carContextMock.Setup(x => x.Models).Returns(modelMock.Object);
            carContextMock.Setup(x => x.Owners).Returns(ownerMock.Object);
            carContextMock.Setup(x => x.Brands).Returns(brandMock.Object);
            carContextMock.Setup(x => x.ProductionYear).Returns(productionYearsMock.Object);

            var command = new CreateCarCmd(carContextMock.Object);
            command.Execute(new BL.Car.DTO.CarDTO { Name="Peugeot"});
            try
            {
                carsMock.Verify(m => m.Add(It.IsAny<Car>()), Times.AtLeastOnce());
                carContextMock.Verify(m => m.Save(), Times.AtLeastOnce());
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }
        [Test]
        public void Update_Car_By_Id()
        {
            
            var carContextMock = new Mock<DB.Interface.IDatabaseService>();
            carContextMock.Setup(x => x.Cars).Returns(carsMock.Object);
            carContextMock.Setup(x => x.Models).Returns(modelMock.Object);
            carContextMock.Setup(x => x.Owners).Returns(ownerMock.Object);
            carContextMock.Setup(x => x.Brands).Returns(brandMock.Object);
            carContextMock.Setup(x => x.ProductionYear).Returns(productionYearsMock.Object);
            IDatabaseService _context = carContextMock.Object;

            CarDTO carDto = new CarDTO { Name = "Volkswagen", Id = 2 };

            
            var carBeforUpdate = _context.Cars.Where(x => x.CarID == carDto.Id).FirstOrDefault();
            var updateCar = new UpdateCar(carContextMock.Object);
            updateCar.Execute(carDto);
            var carAfterUpdate = _context.Cars.Where(x => x.CarID == carDto.Id).FirstOrDefault();
            Assert.AreEqual(carAfterUpdate.Name, "Volkswagen");

            try
            {
                carContextMock.Verify(m => m.Save(), Times.AtLeastOnce());
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }

        }
    }
}
