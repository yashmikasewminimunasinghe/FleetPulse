namespace FleetPulse.Models
{
    public class TripUser
    {
        internal int tripid;

        public int UserId { get; set; }
        public User User { get; set; }
        public string TripId { get; set; }
        public Trip Trip { get; set; }
        public HelperId { get; internal set; }
        public object EndLocation { get; internal set; }
        public object EndMeterId { get; internal set; }
        public object EndTimeId { get; internal set; }
        public object DriverId { get; internal set; }
        public object StartTimeId { get; internal set; }
        public object StartLocation { get; internal set; }
        public object Status { get; internal set; }
        public object VehicleId { get; internal set; }
        public object StartMeter { get; internal set; }
        public object Date { get; internal set; }
    }
}
