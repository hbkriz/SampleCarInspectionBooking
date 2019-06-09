using System;

namespace VehicleIdentificationApi.Models
{
    public class VehicleDetail
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

        public DateTime LastModifiedOn
        {
            get { return _lastModifiedOn; }
            set { _lastModifiedOn = value; }
        }

        public VehicleDetail CopyFrom(VehicleDetail rhs)
        {
            this.RegistrationNumber = rhs.RegistrationNumber;
            this.VehicleColour = rhs.VehicleColour;
            this.VehicleMake = rhs.VehicleMake;
            this.VehicleModel = rhs.VehicleModel;
            this.VehicleCapacity = rhs.VehicleCapacity;
            this.VehicleVariant = rhs.VehicleVariant;
            this.NumberOfDoors = rhs.NumberOfDoors;
            this.Mileage = rhs.Mileage;
            this.LastModifiedOn = DateTime.Now;
            return this;
        }

        private DateTime _lastModifiedOn = DateTime.Now;
    }
}