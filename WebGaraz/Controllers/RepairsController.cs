using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Repair.Services;
using BL.Repair.DTO;
using System.Net;
using WebGaraz.Models.Repair;

namespace WebGaraz.Controllers
{
    public class RepairsController : Controller
    {
        private IRepairService _repairService;
        public RepairsController(IRepairService repairService)
        {
            _repairService = repairService;
        }
        // GET: Repairs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRepairs()
        {
            var allRepairs = _repairService.GetAll().Select(x=> new RepairModel {Id = x.Id ,Name = x.Name,Date = x.Date.ToString(),Note = x.Note,CarId = x.CarId,Brand = x.Brand, Model = x.Model,PlateNumber = x.PlateNumber}).ToList();
            return Json(allRepairs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddRepair(RepairModel repairModel)
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
                //var isAlreadyCreated = _getCarByPlateNumber.Execute(carDTO.PlateNumber) == null ? false : true;
                //if (isAlreadyCreated)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Car with this plate number already exist");
                //}
                var repairDto = new RepairDTO();
                repairDto.Name = repairModel.Name;
                repairDto.Date = !string.IsNullOrEmpty(repairModel.Date) ? DateTime.Parse(repairModel.Date) : DateTime.MinValue;
                repairDto.Note = repairModel.Note;
                repairDto.CarId = repairModel.CarId;

                _repairService.AddRepair(repairDto);
                return new HttpStatusCodeResult(HttpStatusCode.Created);

            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}