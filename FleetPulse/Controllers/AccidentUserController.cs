using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccidentUserController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;

        public object AccidentUserData { get; private set; }

        public AccidentUserController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AccidentUser>> Get()
        {
            return await _context.AccidentUser.ToListAsync();
        }

        [HttpGet("{accidentid}")]
        public async Task<IActionResult> Get(int accidentid)
        {
            if (accidentid < 1)
                return BadRequest();

            // not clear
            var AccidentUser = await _context.AccidentUser.FirstOrDefaultAsync(m => m.Id == accidentid);
            if (AccidentUser == null)
                return NotFound();
            return Ok(AccidentUser);
        }


        [HttpPost]
        public async Task<IActionResult> Post(AccidentUser AccidentUser)
        {
            _context.Add(AccidentUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(AccidentUser AccidenUsertData)
        {
            if (AccidentUserData == null || AccidentUserData.accidentid == 0)
                return BadRequest();

            var AccidentUser = await _context.AccidentUser.FindAsync(AccidentUserData.accidentid);
            if (AccidentUser == null)
                return NotFound();
            AccidentUser.Date = AccidentUserData.Date;
            AccidentUser.Time = AccidentUserData.Time;
            AccidentUser.Venue = AccidentUserData.Venue;
            AccidentUser.Status = AccidentUserData.Status;
            AccidentUser.DriverInjuredStatus = AccidentUserData.DriverInjuredStatus;
            AccidentUser.HelperInjuredStatus = AccidentUserData.HelperInjuredStatus;
            AccidentUser.VehicleDamagedStatus = AccidentUserData.VehicleDamagedStatus;
            AccidentUser.LossStatement = AccidentUserData.LossStatement;
            AccidentUser.SpecialNotes = AccidentUserData.SpecialNotes;
            AccidentUser.Photos = AccidentUserData.Photos;
            AccidentUser.DriverId = AccidentUserData.DriverId;
            AccidentUser.HelperId = AccidentUserData.HelperId;
            AccidentUser.VehicleId = AccidentUserData.VehicleId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{accidentid}")]
        public async Task<IActionResult> Delete(int accidentid)
        {
            if (accidentid < 1)
                return BadRequest();
            var Accident = await _context.AccidentUser.FindAsync(accidentid);
            if (Accident == null)
                return NotFound();
            _context.AccidentUser.Remove(AccidentUser);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
