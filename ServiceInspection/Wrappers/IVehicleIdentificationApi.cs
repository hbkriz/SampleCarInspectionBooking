using System.Threading.Tasks;
using ServiceInspection.DTOs;

namespace ServiceInspection.Wrappers
{
    public interface IVehicleIdentificationApi
    {
        Task<VehicleDetailDto> GetVehicleDetail(string regNumber);
        Task<VehicleDetailDto> UpdateVehicleDetail(string regNumber, VehicleDetailDto vehicle);
    }
}