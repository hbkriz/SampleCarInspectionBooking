using System.Threading.Tasks;
using ServiceInspection.DTOs;

namespace ServiceInspection.Wrappers
{
    public class VehicleIdentificationApi : IVehicleIdentificationApi
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        public VehicleIdentificationApi(IConfigurationManagerWrapper configurationManager, IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            _httpClientWrapper.Initialize(configurationManager.GetAppSetting("VehicleIdentificationApiUrl"), "Vehicle Identification Api");
        }

        public Task<VehicleDetailDto> GetVehicleDetail(string regNumber)
        {
            var apiMethod = string.Format("NumberPlate/GetCarDetails?regNumber={0}", regNumber);
            return _httpClientWrapper.GetAsync<VehicleDetailDto>(apiMethod);
        }

        public Task<VehicleDetailDto> UpdateVehicleDetail(string regNumber, VehicleDetailDto vehicle)
        {
            var apiMethod = string.Format("NumberPlate/UpdateCarDetails?regNumber={0}", regNumber);
            return _httpClientWrapper.PostAsJsonAsync<VehicleDetailDto>(apiMethod, vehicle);
        }

    }
}