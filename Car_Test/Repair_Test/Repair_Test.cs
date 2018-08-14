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
using BL.Repair.Services;

namespace Car_Test.Repair_Test
{
    [TestFixture]
    class Repair_Test
    {
        private Mock<DbSet<Repair>> repairsMock;
        private Mock<DbSet<Car>> carsMock;
        private Mock<DbSet<RepairNotes>> emptyRepairNotesMock;

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

            var emptyRepairNotes = new List<RepairNotes>().AsQueryable();
            emptyRepairNotesMock = new Mock<DbSet<RepairNotes>>();
            emptyRepairNotesMock.As<IQueryable<RepairNotes>>().Setup(m => m.Provider).Returns(emptyRepairNotes.Provider);
            emptyRepairNotesMock.As<IQueryable<RepairNotes>>().Setup(m => m.Expression).Returns(emptyRepairNotes.Expression);
            emptyRepairNotesMock.As<IQueryable<RepairNotes>>().Setup(m => m.ElementType).Returns(emptyRepairNotes.ElementType);
            emptyRepairNotesMock.As<IQueryable<RepairNotes>>().Setup(m => m.GetEnumerator()).Returns(emptyRepairNotes.GetEnumerator());

            var repairs = new List<Repair> {

                    fixture.Build<Repair>().With(u => u.RepairID, 1).With(u => u.Name,"Rozrzad").With(u => u.Car, fixture.Build<Car>().With(u => u.CarID, 3).With(u => u.Name,"Skoda").Create()).Create(),
                    fixture.Build<Repair>().With(u => u.RepairID, 2).With(u => u.Name,"Wymiana Oleju").With(u => u.Car, fixture.Build<Car>().With(u => u.CarID, 3).With(u => u.Name,"Skoda").Create()).Create(),
                    fixture.Build<Repair>().With(u => u.RepairID, 3).With(u => u.Name,"Sprzeglo").With(u => u.Car, fixture.Build<Car>().With(u => u.CarID, 2).With(u => u.Name,"Skoda").Create()).Create()
                    }.AsQueryable();

            repairsMock = new Mock<DbSet<Repair>>();
            repairsMock.As<IQueryable<Repair>>().Setup(m => m.Provider).Returns(repairs.Provider);
            repairsMock.As<IQueryable<Repair>>().Setup(m => m.Expression).Returns(repairs.Expression);
            repairsMock.As<IQueryable<Repair>>().Setup(m => m.ElementType).Returns(repairs.ElementType);
            repairsMock.As<IQueryable<Repair>>().Setup(m => m.GetEnumerator()).Returns(repairs.GetEnumerator());


        }
        [Test]
        public void Read_All_Repairs()
        {
            var repairContextMock = new Mock<DB.Interface.IDatabaseService>();
            repairContextMock.Setup(x => x.Repairs).Returns(repairsMock.Object);

            var repairService = new RepairService(repairContextMock.Object);
            var repairs = repairService.GetAll();
            Assert.IsTrue(repairs.Count == 3);


        }
        [Test]
        public void Read_All_Repairs_For_Selected_Car()
        {
            var repairContextMock = new Mock<DB.Interface.IDatabaseService>();
            repairContextMock.Setup(x => x.Repairs).Returns(repairsMock.Object);
            repairContextMock.Setup(x => x.Cars).Returns(carsMock.Object);
            var repairService = new RepairService(repairContextMock.Object);
            var carRepairs = repairService.GetAllByCarId(3);
            Assert.IsTrue(carRepairs.Count == 2);
        }
        [Test]
        public void Add_New_Repair()
        {
            var repairContextMock = new Mock<DB.Interface.IDatabaseService>();
            repairContextMock.Setup(x => x.Repairs).Returns(repairsMock.Object);
            repairContextMock.Setup(x => x.Cars).Returns(carsMock.Object);
            repairContextMock.Setup(x => x.RepairNotes).Returns(emptyRepairNotesMock.Object);

            var repairService = new RepairService(repairContextMock.Object);
            repairService.AddRepair(new BL.Repair.DTO.RepairDTO
            {
                CarId = 2,
                Date = DateTime.Parse("9.08.2018 15:53:00"),
                Name = "Olejek",
                Note = "Uzyto oleju 5W40 Valvoline"
            });
            try
            {
                repairsMock.Verify(m => m.Add(It.IsAny<Repair>()), Times.AtLeastOnce());
                repairContextMock.Verify(m => m.Save(), Times.AtLeastOnce());
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }
        [Test]
        public void Update_Existing_Repair()
        {
            var repairContextMock = new Mock<DB.Interface.IDatabaseService>();
            repairContextMock.Setup(x => x.Repairs).Returns(repairsMock.Object);
            repairContextMock.Setup(x => x.Cars).Returns(carsMock.Object);
            repairContextMock.Setup(x => x.RepairNotes).Returns(emptyRepairNotesMock.Object);

            var repairService = new RepairService(repairContextMock.Object);
            repairService.UpdateRepair(new BL.Repair.DTO.RepairDTO
            {
                Id = 1,
                CarId = 2,
                Date = DateTime.Parse("10.08.2018 15:53:00"),
                Name = "Olejek",
                Note = "Uzyto oleju 5W30 Valvoline"
            });
            try
            {
               // repairsMock.Verify(m => m.Add(It.IsAny<Repair>()), Times.AtLeastOnce());
                repairContextMock.Verify(m => m.Save(), Times.AtLeastOnce());
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }
        [Test]
        public void Add_New_Note_To_Repair()
        {
            var repairContextMock = new Mock<DB.Interface.IDatabaseService>();
            repairContextMock.Setup(x => x.Repairs).Returns(repairsMock.Object);
            repairContextMock.Setup(x => x.Cars).Returns(carsMock.Object);
            repairContextMock.Setup(x => x.RepairNotes).Returns(emptyRepairNotesMock.Object);

            RepairService repairService = new RepairService(repairContextMock.Object);
            repairService.AddNote(new BL.Repair.DTO.RepairDTO
            {
                Id = 1,
                Note = "Filtr OE650/1",
                Date = DateTime.Parse("10.08.2018 15:53:00")
            });
            try
            {
                emptyRepairNotesMock.Verify(m => m.Add(It.IsAny<RepairNotes>()), Times.AtLeastOnce());
                repairContextMock.Verify(m => m.Save(), Times.AtLeastOnce());
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }
        [Test]
        public void Update_Note()
        {
            var repairContextMock = new Mock<DB.Interface.IDatabaseService>();
            repairContextMock.Setup(x => x.Repairs).Returns(repairsMock.Object);
            repairContextMock.Setup(x => x.Cars).Returns(carsMock.Object);
            repairContextMock.Setup(x => x.RepairNotes).Returns(emptyRepairNotesMock.Object);

            var repairService = new RepairService(repairContextMock.Object);
            repairService.UpdateNote(new BL.Repair.DTO.RepairDTO
            {
                Id = 1,
                CarId = 2,
                Date = DateTime.Parse("10.08.2018 15:53:00"),
                Name = "Olejek",
                Note = "Uzyto oleju 5W30 Valvoline"
            });
            Assert.IsTrue(false);
        }
        [Test]
        public void Delete_Note()
        {
            Assert.IsTrue(false);
        }
    }
}
