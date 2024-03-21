namespace FleetPulse.Models
{
    public class Manufacture
    {
        internal int vehicleid;

        public int ManufactureId { get; set; }
        public string Manufacturer { get; set; }
        public bool Status { get; set; }

        //Vehicle
        public ICollection<Vehicle> Vehicles { get; set; }
        public object VehicleTypeId { get; internal set; }
        public object VehicleId { get; internal set; }
        public object VehicleType { get; internal set; }
    }
}
