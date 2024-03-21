namespace FleetPulse.Models
{
    public class VehicleType
    {
        internal object vehicleid;

        public int VehicleTypeId { get; set; }
        public string Type { get; set; }

        //Vehicle
        public ICollection<Vehicle> Vehicles { get; set; }
        public object VehicleType { get; internal set; }
        public object Status { get; internal set; }
    }
}
