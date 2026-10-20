using System.Security.Claims;
using Assesment_API_TokaReda.DTOs.Application;
using Assesment_API_TokaReda.DTOs.Company;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_API_TokaReda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public ApplicationController(IUnitOfWork unit, IMapper map)
        {
            _unit = unit;
            _mapper = map;
        }

        [HttpPost]
        public IActionResult Add(CreateApplicationDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var j = _mapper.Map<Application>(dto);
            _unit.application.Add(j);
            _unit.Save();
            return Created();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var s = await _unit.application.GetAll();
            var dto = _mapper.Map<List<GetApplicationDTO>>(s);
            return Ok(dto);
        }

        [HttpPatch("{id}/status")]
      //  [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Patch(int id, string status)
        {
            var j = await _unit.application.GetById(id);
            if (j == null) { return NotFound(); }
            if(status.ToLower()!= "under review"&& status.ToLower() != "pending"&&status.ToLower() != "accepted"&& status.ToLower() != "refuesd")
            {
                return BadRequest("the status out of system scope");
            }

            j.Status = status;
            _unit.application.Update(j);
            _unit.Save();
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles ="Candidate")]
        public async Task<IActionResult> AppsSubmittedByCandidate()
        {
            var candidateid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var a=await _unit.application.AppsSubmittedByCandidate(candidateid);

            var dto = _mapper.Map<List<GetApplicationDTO>>(a);
            return Ok(dto);
        }

    }
}
