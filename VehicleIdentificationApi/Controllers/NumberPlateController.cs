using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using VehicleIdentificationApi.Models;
using VehicleIdentificationApi.Service;

namespace VehicleIdentificationApi.Controllers
{
    [RoutePrefix("api/NumberPlate")]
    public class NumberPlateController : ApiController
    {
        private readonly MockDataService _vservice;
        private NumberPlateController()
        {
            _vservice = new MockDataService();
        }

        [Route("GetCarDetails")]
        [HttpGet]
        public VehicleDetail Get(string regNumber)
        {
            var vehicleDetails = _vservice.VehicleDetails.Where(m => m.RegistrationNumber == regNumber.ToUpper()).ToList();
            if (!vehicleDetails.Any())
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return vehicleDetails.FirstOrDefault();
        }

        [Route("UpdateCarDetails")]
        [HttpPost]
        public IHttpActionResult Post(string regNumber, VehicleDetail vehicleDetail)
        {
            try
            {
                return Ok(_vservice.Update(regNumber, vehicleDetail));
            }
            catch (ArgumentNullException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
