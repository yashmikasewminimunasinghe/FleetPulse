
namespace FleetPulse.Models
{
    public class Trip
    {
        internal int tripid;
        internal int userid;

        public string TripId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StarTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public float StartMeterValue { get; set; }
        public float EndMeterValue { get; set; }
        public bool Status { get; set; }

        //Vehicle

        public ICollection<Vehicles> Vehicles { get; set; }

        //TripUser
        public IList<TripUser> TripUsers { get; set; }
        public object StartMeter { get; internal set; }
        public object EndTimeId { get; internal set; }
        public object EndMeterId { get; internal set; }
        public object HelperId { get; internal set; }
        public object VehicleId { get; internal set; }
        public object DriverId { get; internal set; }
        public object StartTimeId { get; internal set; }
        public object ProfilePicture { get; internal set; }
        public object DateOfBirth { get; internal set; }
        public object PhoneNo { get; internal set; }
        public object EmergencyContact { get; internal set; }
        public object NIC { get; internal set; }
        public object ConfirmPassword { get; internal set; }
        public object Password { get; internal set; }
        public object EmailAddress { get; internal set; }
        public object LastName { get; internal set; }
        public object FirstName { get; internal set; }
        public object UserName { get; internal set; }
    }
}
