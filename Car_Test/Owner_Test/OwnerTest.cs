using AutoFixture;
using BL.Owner.Service;
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

namespace Car_Test.Owner_Test
{
    class OwnerTest
    {
        private Mock<DbSet<Owner>> ownerMock;

        [SetUp]
        public void Setup()
        {
            Fixture fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var owners = new List<Owner>
                      {
                        fixture.Build<Owner>().With(u => u.OwnerID, 1).With(u => u.Name,"Mateo").Create(),
                        fixture.Build<Owner>().With(u => u.OwnerID, 2).With(u => u.Name,"Malinowski").Create(),
                        fixture.Build<Owner>().With(u => u.OwnerID, 3).With(u => u.Name,"Malinowski").Create(),
                        fixture.Build<Owner>().With(u => u.OwnerID, 4).With(u => u.Name,"Malinowski").Create(),
                        fixture.Build<Owner>().With(u => u.OwnerID, 5).With(u => u.Name,"Malinowski").Create(),
                        fixture.Build<Owner>().With(u => u.OwnerID, 6).With(u => u.Name,"Malinowski").Create()
                      }.AsQueryable();
            ownerMock = new Mock<DbSet<Owner>>();
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.Provider).Returns(owners.Provider);
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.Expression).Returns(owners.Expression);
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.ElementType).Returns(owners.ElementType);
            ownerMock.As<IQueryable<Owner>>().Setup(m => m.GetEnumerator()).Returns(owners.GetEnumerator());
        }
        [Test]
        public void Get_All_Owners()
        {
            var ownerContextMock = new Mock<IDatabaseService>();
            ownerContextMock.Setup(m => m.Owners).Returns(ownerMock.Object);
            var ownerService = new OwnerService(ownerContextMock.Object);
            var owners = ownerService.GetAll();

            Assert.IsTrue(owners.Count == 6);
        }
        public void Get_Owner_By_Id()
        {
            Assert.IsTrue(false);
        }
    }
}
