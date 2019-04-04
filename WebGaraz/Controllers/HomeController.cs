using BL.Brand.DTO;
using BL.Car.Services;
using BL.Engine;
using BL.Model.DTO;
using BL.Owner.DTO;
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
        public ActionResult AllCarsRegistered()
        {
            var allCars = _getAllCarsCommand.Execute();
            return Json(allCars, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllCars()
        {
            var allCars = new List<BrandDTO>() {
                new BrandDTO { Name = "VW"   ,ID=1 },
                new BrandDTO { Name = "Audi" ,ID=2 },
                new BrandDTO { Name = "Skoda",ID=3 },
                new BrandDTO { Name = "BMW"  ,ID=4 },
                new BrandDTO { Name = "Ford" ,ID=5 },
                new BrandDTO { Name = "Fiat" ,ID=6 },
            };
            return Json(allCars, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllModels(int id)
        {
            var allModel = new List<ModelDTO>();
            if (id == 2)
            {
                allModel.AddRange(new List<ModelDTO>(){
                new ModelDTO{ Name = "A4",ID = 1 },
                new ModelDTO{ Name = "A6",ID = 2},
                new ModelDTO{ Name = "A3",ID = 3 },
                new ModelDTO{ Name = "A8",ID = 4 },
                new ModelDTO{ Name = "Q5",ID = 5 },
                new ModelDTO{ Name = "Q7",ID = 6 },
            });
            }

            return Json(allModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllEnginesForCarByBrandIdAndModelId(int brandId, int modelId)
        {
            var allEngine = new List<EngineDTO>();
            if (brandId == 2 && modelId == 1)
            {
                allEngine.AddRange(
                    new List<EngineDTO>()
                    {
                        new EngineDTO{Name = "1.9TDI 115KM", ID = 1},
                        new EngineDTO{Name = "1.9TDI 90KM", ID = 2},
                        new EngineDTO{Name = "1.9TDI 130KM", ID = 3},
                        new EngineDTO{Name = "1.9TDI 150KM", ID = 4}

                    });
            }
            return Json(allEngine, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AllOwners()
        {
            var allOwners = new List<OwnerDTO>()
            {
                new OwnerDTO
                {
                    ID = 1,
                    Name = "Mateusz Kalinowski"
                },
                new OwnerDTO
                {
                    ID = 2,
                    Name = "Adam Zalinowski"
                },
                new OwnerDTO
                {
                    ID = 3,
                    Name = "Wojciech Palinowski"
                }
            };

            return Json(allOwners, JsonRequestBehavior.AllowGet);

        }
        

    }


}