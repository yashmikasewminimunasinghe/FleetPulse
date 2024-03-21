using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;

        public TripController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Trip>> Get()
        {
            return await _context.Trip.ToListAsync();
        }

        [HttpGet("{tripid}")]
        public async Task<IActionResult> Get(int tripid)
        {
            if (tripid < 1)
                return BadRequest();

            // not clear
            var Trip = await _context.Trip.FirstOrDefaultAsync(m => m.Id == tripid);
            if (Trip == null)
                return NotFound();
            return Ok(Trip);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Trip Trip)
        {
            _context.Add(Trip);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Trip TripData)
        {
            if (TripData == null || TripData.tripid == 0)
                return BadRequest();

            var Trip = await _context.Trip.FindAsync(Trip.tripid);
            if (Trip == null)
                return NotFound();
            Trip.DriverId = TripData.DriverId;
            Trip.HelperId = TripData.HelperId;
            Trip.VehicleId = TripData.VehicleId;
            Trip.Date = TripData.Date;
            Trip.StartTimeId = TripData.StartTimeId;
            Trip.EndTimeId = TripData.EndTimeId;
            Trip.StartLocation = TripData.StartLocation;
            Trip.EndLocation = TripData.EndLocation;
            Trip.StartMeterValue = TripData.StartMeter;
            Trip.EndMeterValue = TripData.EndMeterId;
            Trip.Status = TripData.Status;


            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{tripid}")]
        public async Task<IActionResult> Delete(int tripid)
        {
            if (tripid < 1)
                return BadRequest();
            var Trip = await _context.Trip.FindAsync(tripid);
            if (Trip == null)
                return NotFound();
            _context.Trip.Remove(Trip);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
