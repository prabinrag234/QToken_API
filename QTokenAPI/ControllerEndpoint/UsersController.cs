using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QTokenAPI.DataTransferObject;
using QTokenAPI.DBContext;
using QTokenAPI.EntityModels;

namespace QTokenAPI.ControllerEndpoint
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly QTokenDBContext _context;

        public UsersController(QTokenDBContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDTO dto)
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user == null)
                return Unauthorized("Invalid username");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isValid)
                return Unauthorized("Invalid password");

            return Ok(new
            {
                message = "Login successful",
                userId = user.UserId,
                role = user.Role
            });
        }


        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
