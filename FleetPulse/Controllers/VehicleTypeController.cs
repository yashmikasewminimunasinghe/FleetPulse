using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;

        public object Status { get; private set; }

        public VehicleTypeController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleType>> Get()
        {
            return await _context.VehicleType.ToListAsync();
        }

        [HttpGet("{vehicleid}")]
        public async Task<IActionResult> Get(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();

            // not clear
            var VehicleType = await _context.VehicleType.FirstOrDefaultAsync(m => m.Id == vehicleid);
            if (VehicleType == null)
                return NotFound();
            return Ok(VehicleType);
        }


        [HttpPost]
        public async Task<IActionResult> Post(VehicleType VehicleType)
        {
            _context.Add(VehicleType);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VehicleType VehicleTypeData)
        {
            if (VehicleTypeData == null || VehicleTypeData.vehicleid == 0)
                return BadRequest();

            var VehicleType = await _context.VehicleType.FindAsync(VehicleType.vehicleid);
            if (VehicleType == null)
                return NotFound();
            VehicleType.VehicleTypeId = VehicleTypeData.VehicleTypeId;
            VehicleType.VehicleType = VehicleTypeData.VehicleType;
            Vehicle Type.Status = VehicleTypeData.Status;
            //same one id
            VehicleType.VehicleId = VehicleTypeData.vehicleid;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{vehicleid}")]
        public async Task<IActionResult> Delete(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();
            var VehicleType = await _context.VehicleType.FindAsync(vehicleid);
            if (VehicleType == null)
                return NotFound();
            _context.VehicleType.Remove(VehicleType);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
