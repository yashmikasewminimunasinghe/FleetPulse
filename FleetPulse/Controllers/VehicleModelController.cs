using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;

        public VehicleModelController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleModel>> Get()
        {
            return await _context.VehicleModel.ToListAsync();
        }

        [HttpGet("{vehicleid}")]
        public async Task<IActionResult> Get(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();

            // not clear
            var VehicleModel = await _context.VehicleModel.FirstOrDefaultAsync(m => m.Id == vehicleid);
            if (VehicleModel == null)
                return NotFound();
            return Ok(VehicleModel);
        }


        [HttpPost]
        public async Task<IActionResult> Post(VehicleModel VehicleModel)
        {
            _context.Add(VehicleModel);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VehicleModel VehicleModelData)
        {
            if (VehicleModelData == null || VehicleModelData.vehicleid == 0)
                return BadRequest();

            var VehicleModel = await _context.VehicleModel.FindAsync(VehicleModel.vehicleid);
            if (VehicleModel == null)
                return NotFound();
            VehicleModel.VehicleTypeId = VehicleModelData.VehicleTypeId;
            VehicleModel.VehicleType = VehicleModelData.VehicleType;
            VehicleModel.Status = VehicleModelData.Status;
            //same one id
            VehicleModel.VehicleId= VehicleModelData.vehicleid;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{vehicleid}")]
        public async Task<IActionResult> Delete(int vehicleid)
        {
            if (vehicleid < 1)
                return BadRequest();
            var TripUser = await _context.VehicleModel.FindAsync(vehicleid);
            if (TripUser == null)
                return NotFound();
            _context.VehicleModel.Remove(VehicleModel);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}

