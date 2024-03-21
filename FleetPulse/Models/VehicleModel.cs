namespace FleetPulse.Models
{
    public class VehicleModel
    {
        internal object vehicleid;

        public int VehicleModelId { get; set; }
        public string Model { get; set; }
        public bool Status { get; set; }

        //Vehicle
        public ICollection<Vehicle> Vehicles { get; set; }
        public object VehicleType { get; internal set; }
    }
}
