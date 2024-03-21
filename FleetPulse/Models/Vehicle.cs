namespace FleetPulse.Models
{
    public class Vehicle
    {
        internal object vehicleid;

        public int VehicleId { get; set; }
        public string VhicleRgistrationNo { get; set; }
        public string LicenseNo { get; set; }
        public DateTime LicenseExpireDate { get; set; }
        public string VehicleColor { get; set; }
        public string Status { get; set; }

        //VehicleModel
        public int VehicleModelId { get; set; }
        public VehicleModel Model { get; set; }
        

        //VehicleType
        public int VehicleTypeId { get; set; }
        public VehicleType Type { get; set; }

        //Vehicle_Manufacturer
        public int ManufactureId { get; set; }
        public Manufacture Manufacturer { get; set; }


        //Fuel_Refill
        public int FuelRefillId { get; set; }
        public FuelRefill FType { get; set; }

        //Vehicle_Maintenance

         public string VehicleMaintenanceId { get; set; }
        public VehicleMaintenance VehicleMaintenance { get; set; }

        //Accident

        public int AccidentId { get; set; }
        public Accident Accident { get; set; }


        //Trip
        public string TripId { get; set; }
        public Trip Trip { get; set; }
        public object Color { get; internal set; }
        public object VehicleRegNo { get; internal set; }
        public object HelperId { get; internal set; }
        public object DriverId { get; internal set; }
    }
}
