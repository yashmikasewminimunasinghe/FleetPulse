namespace FleetPulse.Data
{
    public class FleetPulseDBContext
    {
        internal object Accident;

        public object Vehicles { get; internal set; }
        public object VehicleType { get; internal set; }
        public object AccidentUser { get; internal set; }
        public object Manufacture { get; internal set; }
        public object Trip { get; internal set; }
        public object TripUser { get; internal set; }
        public object User { get; internal set; }
        public object VehicleModel { get; internal set; }
        public object Accidents { get; internal set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
