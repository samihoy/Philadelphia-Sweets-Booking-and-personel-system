using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.EmployeeDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Philadelphia_Sweets_booking_System__Resturant_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeServices _EmployeeService;
        private readonly PhiladelphiaSweetsResturandDBContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(IEmployeeServices services, PhiladelphiaSweetsResturandDBContext context, IConfiguration configuration)
        {
            _EmployeeService = services;
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register( EmployeeRegisterDTO newUser)
        {
            var existingUser = await _context.Employees.FirstOrDefaultAsync(e => e.Email == newUser.Email);

            if(existingUser!=null)
            {
                return BadRequest("Email alaredy in system");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            newUser.Password = passwordHash;

            var newUserId = await _EmployeeService.RegisterEmployeeServicesAsync(newUser);
            return Ok(newUserId);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(EmployeeLoginDTO loginUser)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(u => u.Email == loginUser.Email);

            if(user==null)
            {
                return NotFound("No user in the system with that email");
            }

            bool passwordMatch = BCrypt.Net.BCrypt.Verify(loginUser.Password,user.PasswordHash);
            
            if(!passwordMatch)
            {
                return Unauthorized("Invalid password");
            }

            var token = GenerateJwtToken(user);
            return Ok(new {token});
        }
        private string GenerateJwtToken(Employee employee)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{employee.Fname} {employee.Lname}"),
                new Claim(ClaimTypes.Email, employee.Email),
                new Claim(ClaimTypes.Role, employee.Role)
            });

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDiscriptor);
            return tokenHandler.WriteToken(token);
        
        }

    }
}
