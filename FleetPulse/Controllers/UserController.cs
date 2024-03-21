using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetPulse.Models;
using FleetPulse.Data;

namespace FleetPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FleetPulseDBContext _context;
        private int tripid;

        public UserController(FleetPulseDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _context.User.ToListAsync();
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> Get(int userid)
        {
            if (userid < 1)
                return BadRequest();

            // not clear
            var User = await _context.User.FirstOrDefaultAsync(m => m.Id == userid);
            if (User == null)
                return NotFound();
            return Ok(User);
        }


        [HttpPost]
        public async Task<IActionResult> Post(User User)
        {
            _context.Add(User);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Trip UserData)
        {
            if (UserData == null || UserData.userid == 0)
                return BadRequest();

            var User = await _context.User.FindAsync(User.userid);
            if (User == null)
                return NotFound();
            User.FirstName = UserData.FirstName;
            User.LastName = UserData.LastName;
            User.UserName = UserData.UserName;
            User.Password = UserData.Password;
            User.ConfirmPassword = UserData.ConfirmPassword;
            User.EmailAddress = UserData.EmailAddress;
            User.PhoneNo = UserData.PhoneNo;
            User.DateOfBirth = UserData.DateOfBirth;
            User.EmergencyContact = UserData.EmergencyContact;
            User.NIC = UserData.NIC;
            User.ProfilePicture = UserData.ProfilePicture;
            User.Status = UserData.Status;



            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{userid}")]
        public async Task<IActionResult> Delete(int userid)
        {
            if (tripid < 1)
                return BadRequest();
            var Trip = await _context.User.FindAsync(userid);
            if (Trip == null)
                return NotFound();
            _context.User.Remove(User);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
