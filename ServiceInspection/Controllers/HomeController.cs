using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ServiceInspection.DTOs;
using ServiceInspection.Wrappers;

namespace ServiceInspection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleIdentificationApi _vehicleIdentificationApi;
        public HomeController() : this(new VehicleIdentificationApi(new ConfigurationManagerWrapper(), new HttpClientWrapper()))
        {

        }

        public HomeController(IVehicleIdentificationApi vehicleIdentificationApi)
        {
            _vehicleIdentificationApi = vehicleIdentificationApi;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string regNumber)
        {
            if (ModelState.IsValid)
            {
                var apiResponse = await _vehicleIdentificationApi.GetVehicleDetail(regNumber);
                return RedirectToAction("VehicleDetail", apiResponse);
            }

            return View();
        }

        [HttpGet]
        public ActionResult VehicleDetail(VehicleDetailDto vehicleDetail)
        {
            return View(vehicleDetail);
        }

        [HttpPost]
        public async Task<ActionResult> VehicleDetail(string regNumber, VehicleDetailDto vehicleDetail)
        {
            if (ModelState.IsValid)
            {
                var apiResponse = await _vehicleIdentificationApi.UpdateVehicleDetail(vehicleDetail.RegistrationNumber, vehicleDetail);
                return View(apiResponse);
            }
            return View(vehicleDetail);
        }
    }
}