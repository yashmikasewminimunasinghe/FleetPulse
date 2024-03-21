using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;

        public VehiclesController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await _context.Vehicles.ToListAsync();
        }

        [HttpGet("{vehicleid}")]
        public async Task<IActionResult> Get(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();

            // not clear
            var Vehicle = await _context.Vehicles.FirstOrDefaultAsync(m => m.Id == vehicleid);
            if (Vehicle == null)
                return NotFound();
            return Ok(Vehicle);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Vehicle Vehicle)
        {
            object value = _context.Add(Vehicle);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vehicle VehicleData)
        {
            if (VehicleData == null || VehicleData.VehicleId == 0)
                return BadRequest();

            var Vehicle = await _context.Vehicles.FindAsync(VehicleData.vehicleid);
            if (Vehicle == null)
                return NotFound();
            Vehicle.VehicleRegNo = VehicleData.VehicleRegNo;
            Vehicle.LicenseNo = VehicleData.LicenseNo;
            Vehicle.LicenseExpireDate = VehicleData.LicenseExpireDate;
            Vehicle.Color = VehicleData.Color;
            Vehicle.Status = VehicleData.Status;
            Vehicle.DriverId = VehicleData.DriverId;
            Vehicle.HelperId = VehicleData.HelperId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{vehicleid}")]
        public async Task<IActionResult> Delete(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();
            var Vehicle = await _context.Vehicles.FindAsync(vehicleid);
            if (Vehicle == null)
                return NotFound();
            _context.Vehicles.Remove(Vehicle);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}