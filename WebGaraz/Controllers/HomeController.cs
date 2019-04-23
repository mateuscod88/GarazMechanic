using BL.Brand.DTO;
using BL.Brand.Service;
using BL.Car.DTO;
using BL.Car.Services;
using BL.Engine;
using BL.Engine.Service;
using BL.Model.DTO;
using BL.Model.Service;
using BL.Owner.DTO;
using BL.Owner.Service;
using DB;
using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGaraz.Models.Car;

namespace WebGaraz.Controllers
{
    public class HomeController : Controller
    {
        private IGetAllCars _getAllCarsQuery;
        private IGetCarByPlateNumber _getCarByPlateNumber;
        private IGetCarById _getCarByIdCommand;
        private ICreateCar _createCarCommand;
        private IBrandService _brandService;
        private IOwnerService _ownerService;
        private IModelService _modelService;
        private IEngineService _engineService;
        private IDatabaseService _context;
        // GET: Home
        public HomeController(IGetCarByPlateNumber getCarByPlateNumber,IGetCarById getCarByIdCommand,ICreateCar createCarCommand, IBrandService brandService, IModelService modelService, IEngineService engineService, IOwnerService ownerService, IGetAllCars getAllCarsQuery)
        {
            _context = new CarHistoryContext();
            _getCarByPlateNumber = getCarByPlateNumber;
            _createCarCommand = createCarCommand;
            _brandService = brandService;
            _modelService = modelService;
            _engineService = engineService;
            _ownerService = ownerService;
            _getCarByIdCommand = getCarByIdCommand;
            _getAllCarsQuery = getAllCarsQuery;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllCarsRegistered()
        {
            var allCars = _getAllCarsQuery.Execute();
            var allCarsModel = allCars.Select(x => new CarModel { Brand = x.Brand, BrandId = x.BrandId, Engine = x.Engine, HorsePower = x.HorsePower, Id = x.Id, LatestOilChange = "", Model = x.Model, ModelId = x.ModelId, Name = x.Name, OwnerId = x.OwnerId, OwnerName = x.OwnerName, Phone = x.Phone, PlateNumber = x.PlateNumber, TechnicalCheck = x.TechnicalCheck.ToString(), Year = x.Year }).ToList();
            return Json(allCarsModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllBrands()
        {
            var allBrand = _brandService.GetAllBrands();
            return Json(allBrand, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllModels(int id)
        {
            var allModels = _modelService.GetAllModelsByBrandId(id);
            return Json(allModels, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllEnginesForCarByBrandIdAndModelId(int brandId, int modelId)
        {
            var allEngines = _engineService.GetAllByBrandAndModel(brandId,modelId);
            return Json(allEngines, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AllOwners()
        {
            var allOwners = _ownerService.GetAll();
            return Json(allOwners, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult AddCar(CarDTO carDTO)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    var modelErrors = new List<string>();
                    foreach (var value in ModelState.Values)
                    {
                        foreach (var modelError in value.Errors)
                        {
                            modelErrors.Add(modelError.ErrorMessage);
                        }

                    }
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, string.Join(",", modelErrors));
                }
                var isAlreadyCreated = _getCarByPlateNumber.Execute(carDTO.PlateNumber) == null ?  false : true;
                if (isAlreadyCreated)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest,"Car with this plate number already exist");
                }
                _createCarCommand.Execute(carDTO);
                return new HttpStatusCodeResult(HttpStatusCode.Created);

            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
        

    }


}