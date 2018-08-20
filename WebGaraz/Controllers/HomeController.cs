using BL.Car.Services;
using DB;
using DB.Interface;
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
        private IDatabaseService _context;
        // GET: Home
        public HomeController(IGetAllCars getAllCarsCommand)
        {
            _context = new CarHistoryContext();
            _getAllCarsCommand = new GetAllCarQuery(_context);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllCars()
        {
            var allCars = _getAllCarsCommand.Execute();
            return Json(allCars,JsonRequestBehavior.AllowGet);
        }
    }

  
}