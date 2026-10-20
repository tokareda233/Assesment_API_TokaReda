using System.Reflection.Metadata.Ecma335;
using Assesment_API_TokaReda.DTOs.CandidateProfile;
using Assesment_API_TokaReda.DTOs.Company;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_API_TokaReda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateprofileController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public CandidateprofileController(IUnitOfWork unit, IMapper map)
        {
            _unit = unit;
            _mapper = map;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var s = await _unit.CandidateProfile.GetAll();
            var dto = _mapper.Map<List<GetCandidateProfileDTO>>(s);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateCandidateDTO dto)
        {
            var can = await _unit.CandidateProfile.GetById(id);
            if (can == null) { return NotFound(); }

            _mapper.Map(dto, can);
            _unit.CandidateProfile.Update(can);
            _unit.Save();
           return NoContent();
        }


    }
}
