﻿namespace FleetPulse.Models
{
    public class AccidentUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AccidentId { get; set; }
        public Accident Accident { get; set; }
    }
}
