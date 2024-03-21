using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactureController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;

        public ManufactureController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Manufacture>> Get()
        {
            return await _context.Manufacture.ToListAsync();
        }

        [HttpGet("{vehicletid}")]
        public async Task<IActionResult> Get(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();

            
            var Manufacture = await _context.Manufacture.FirstOrDefaultAsync(m => m.Id == vehicleid);
            if (Manufacture == null)
                return NotFound();
            return Ok(Manufacture);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Manufacture Manufacture)
        {
            _context.Add(Manufacture);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Manufacture ManufactureData)
        {
            if (ManufactureData == null || ManufactureData.vehicleid == 0)
                return BadRequest();

            var Manufacture = await _context.Manufacture.FindAsync(ManufactureData.vehicleid);
            if (Manufacture == null)
                return NotFound();
            Manufacture.VehicleTypeId = ManufactureData.VehicleTypeId;
            Manufacture.VehicleType = ManufactureData.VehicleType;
            Manufacture.Status = ManufactureData.Status;
            Manufacture.VehicleId = ManufactureData.VehicleId;
           
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{vehicleid}")]
        public async Task<IActionResult> Delete(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();
            var Manufacture = await _context.Manufacture.FindAsync(vehicleid);
            if (Manufacture == null)
                return NotFound();
            _context.Manufacture.Remove(Manufacture);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}