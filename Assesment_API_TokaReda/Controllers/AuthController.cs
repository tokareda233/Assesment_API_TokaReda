using Assesment_API_TokaReda.DTOs.Auth;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_API_TokaReda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public AuthController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (dto == null||!ModelState.IsValid) { return BadRequest(); }
            var l=await _unit.authRepo.Login(dto);
            if (l==null) { return Unauthorized("email or password Incorrect"); }

            return Ok(l);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            if (dto.Role=="Admin" )
            {
                return BadRequest("Can not Register as Admin");
            }
            var r=await _unit.authRepo.Register(dto);
            if (!r) { return BadRequest("email already exeists"); }

            //if (dto.Role != "Candidate"&&dto.Role!="Employer")
            //{
            //    return BadRequest("Roles out of the system scope");
               
            //}

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = DateTime.Now,
                Role = dto.Role,

            };

            _unit.user.Add(user);
            _unit.Save();
            return Ok("Created successfully");
        }
    }
}
