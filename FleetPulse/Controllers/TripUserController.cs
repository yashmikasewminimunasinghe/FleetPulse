using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripUserController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;

        public TripUserController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Trip>> Get()
        {
            return await _context.TripUser.ToListAsync();
        }

        [HttpGet("{tripid}")]
        public async Task<IActionResult> Get(int tripid)
        {
            if (tripid < 1)
                return BadRequest();

            // not clear
            var TripUser = await _context.TripUser.FirstOrDefaultAsync(m => m.Id == tripid);
            if (TripUser == null)
                return NotFound();
            return Ok(TripUser);
        }


        [HttpPost]
        public async Task<IActionResult> Post(TripUser TripUser)
        {
            _context.Add(TripUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(TripUser TripUserData)
        {
            if (TripUserData == null || TripUserData.tripid == 0)
                return BadRequest();

            var TripUser = await _context.TripUser.FindAsync(TripUser.tripid);
            if (TripUser == null)
                return NotFound();
            TripUser.DriverId = TripUserData.DriverId;
            TripUser.HelperId = TripUserData.HelperId;
            TripUser.VehicleId = TripUserData.VehicleId;
            TripUser.Date = TripUserData.Date;
            TripUser.StartTimeId = TripUserData.StartTimeId;
            TripUser.EndTimeId = TripUserData.EndTimeId;
            TripUser.StartLocation = TripUserData.StartLocation;
            TripUser.EndLocation = TripUserData.EndLocation;
            TripUser.StartMeterValue = TripUserData.StartMeter;
            TripUser.EndMeterValue = TripUserData.EndMeterId;
            TripUser.Status = TripUserData.Status;


            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{tripid}")]
        public async Task<IActionResult> Delete(int tripid)
        {
            if (tripid < 1)
                return BadRequest();
            var TripUser = await _context.TripUser.FindAsync(tripid);
            if (TripUser == null)
                return NotFound();
            _context.TripUser.Remove(TripUser);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}

