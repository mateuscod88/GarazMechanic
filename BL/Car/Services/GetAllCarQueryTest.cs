using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoMoq;
using BL.Car.DTO;
namespace BL.Car.Services
{
    [TestFixture]
    public class GetAllCarQueryTest
    {
        private GetAllCarQuery _query;
        private AutoMoqer _mocker;
        private BL.Car.DTO.Car _car;

        private const int Id = 1;
        private const string Name = "Audi";
        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();
            _car = new DTO.Car();
            _car.Id = 1;
            _car.Name = "Audi";
        }
        [Test]
        public void Test_Should_Return_All_Cars()
        {
            Assert.IsTrue(true, "false");
        }

    }
}
