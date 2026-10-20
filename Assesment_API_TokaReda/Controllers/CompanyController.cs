using Assesment_API_TokaReda.DTOs.Company;
using Assesment_API_TokaReda.DTOs.Job;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_API_TokaReda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public CompanyController(IUnitOfWork unit, IMapper map)
        {
            _unit = unit;
            _mapper = map;
        }

        [HttpPost]
        public IActionResult Add(CreateCompanyDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var j = _mapper.Map<Company>(dto);
            _unit.company.Add(j);
            _unit.Save();
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var s=await _unit.company.GetAll();
            var dto = _mapper.Map <List<GetCompanyDTO>>(s);
            return Ok(dto);
        }

        [HttpGet("most-jobs")]
        public async Task<IActionResult> GetCompanyWithMostJobs()
        {

            var c=await _unit.company.GetTheMostPublishedCompany();
            var dto = _mapper.Map<GetCompanyDTO>(c);

            return Ok(dto);
        }
    }
}
