using BL.Car.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGaraz.Controllers
{
    public class HomeController : Controller
    {
        private IGetAllCars _getAllCarsCommand;
        // GET: Home
        public HomeController(IGetAllCars getAllCarsCommand)
        {
            _getAllCarsCommand = getAllCarsCommand;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllCars()
        {
            var allCars = _getAllCarsCommand.Execute();
            return View();
        }
    }

  
}