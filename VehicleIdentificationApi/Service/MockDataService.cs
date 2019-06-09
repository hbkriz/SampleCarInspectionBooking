using System;
using System.Collections.Generic;
using System.Linq;
using VehicleIdentificationApi.Models;

namespace VehicleIdentificationApi.Service
{
    public class MockDataService
    {
        public List<VehicleDetail> VehicleDetails
        {
            get { return _vehicleDetails; }
        }

        public VehicleDetail Update(string regNumber, VehicleDetail vehicleDetail)
        {
            if (vehicleDetail == null) throw new ArgumentNullException(nameof(vehicleDetail));

            var vehicleDetailFromDb = VehicleDetails.FirstOrDefault(m => m.RegistrationNumber == regNumber.ToUpper());
            if (vehicleDetailFromDb == null) throw new ArgumentException($"Cannot find vehicle with Registration Number: {vehicleDetail.RegistrationNumber}");
            lock (_lock)
            {
                return vehicleDetailFromDb.CopyFrom(vehicleDetail);
            }
        }

        private static readonly List<VehicleDetail> _vehicleDetails = new []
        {
            new VehicleDetail { VehicleDetailId = 1, RegistrationNumber = "NE62 GLF", VehicleColour = VehicleColour.Blue.ToString(), VehicleMake  =  VehicleMake.Volkswagen.ToString(), VehicleModel = VehicleModel.Golf.ToString(), VehicleCapacity = 1.2, VehicleVariant = VehicleVariant.TSI.ToString(), NumberOfDoors = (int)VehicleDoors.Five, Mileage = 25000 },
            new VehicleDetail { VehicleDetailId = 2, RegistrationNumber = "NA05 AXR", VehicleColour = VehicleColour.Red.ToString(), VehicleMake  =  VehicleMake.Audi.ToString(), VehicleModel = VehicleModel.A1.ToString(), VehicleCapacity = 1.0, VehicleVariant = VehicleVariant.TFSI.ToString(), NumberOfDoors = (int)VehicleDoors.Three, Mileage = 19000},
            new VehicleDetail { VehicleDetailId = 3, RegistrationNumber = "KE65 KLM", VehicleColour = VehicleColour.White.ToString(), VehicleMake  =  VehicleMake.Audi.ToString(), VehicleModel = VehicleModel.A3.ToString(), VehicleCapacity = 1.6, VehicleVariant = VehicleVariant.TFSI.ToString(), NumberOfDoors = (int)VehicleDoors.Five, Mileage = 11000},
            new VehicleDetail { VehicleDetailId = 4, RegistrationNumber = "KL12 RTY", VehicleColour = VehicleColour.Black.ToString(), VehicleMake  =  VehicleMake.Skoda.ToString(), VehicleModel = VehicleModel.Yeti.ToString(), VehicleCapacity = 1.6, VehicleVariant = VehicleVariant.TDI.ToString(), NumberOfDoors = (int)VehicleDoors.Five, Mileage = 9000},
            new VehicleDetail { VehicleDetailId = 5, RegistrationNumber = "GJ39 PLF", VehicleColour = VehicleColour.Silver.ToString(), VehicleMake  =  VehicleMake.Skoda.ToString(), VehicleModel = VehicleModel.Fabia.ToString(), VehicleCapacity = 1.2, VehicleVariant = VehicleVariant.TSI.ToString(), NumberOfDoors = (int)VehicleDoors.Three, Mileage = 14000}
        }.ToList();


        private object _lock = new object();
    }
}