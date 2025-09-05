using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QTokenAPI.DataTransferObject;
using QTokenAPI.DBContext;
using QTokenAPI.EntityModels;

namespace QTokenAPI.ControllerEndpoint
{
    [ApiController]
    [Route("api/user/register")]
    public class UsersController : ControllerBase
    {
        private readonly QTokenDBContext _context;

        public UsersController(QTokenDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDto dto)
        {
            // Optional: Check if username already exists
            if (await _context.Users.AnyAsync(u => u.UserName == dto.UserName))
            {
                return BadRequest("Username already taken.");
            }

            var user = new User
            {
                Name = dto.Name,
                UserName = dto.UserName,
                Password = HashPassword(dto.Password), // Optional: hash it!
                Speciality = dto.Speciality,
                Role = dto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registration successful", userId = user.UserId });
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
