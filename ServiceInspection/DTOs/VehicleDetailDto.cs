using System;

namespace ServiceInspection.DTOs
{
    public class VehicleDetailDto
    {
        public int VehicleDetailId { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleColour { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public double VehicleCapacity { get; set; }
        public string VehicleVariant { get; set; }
        public int NumberOfDoors { get; set; }
        public double Mileage { get; set; }
        public DateTime LastModifiedOn { get; set;  }
    }
}