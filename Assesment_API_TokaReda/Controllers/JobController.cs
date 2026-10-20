using Assesment_API_TokaReda.Data;
using Assesment_API_TokaReda.DTOs.Company;
using Assesment_API_TokaReda.DTOs.Job;
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
    public class JobController : ControllerBase
    {

        // test commit 1
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public JobController(IUnitOfWork unit,IMapper map)
        {
            _unit = unit;
            _mapper = map;
        }

        [HttpPost]
        public IActionResult Add(CreateJobDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            if (dto.Deadline < dto.PostedDate) { return BadRequest("deadline must be after postedDate"); }

            var j = _mapper.Map<Job>(dto);
            _unit.job.Add(j);
            _unit.Save();
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var s = await _unit.job.GetAll();
            var dto = _mapper.Map<List<GetJobDTO>>(s);
            return Ok(dto);
        }

        [HttpGet("third-highest-salay")]
        public async Task<IActionResult> GetHighestSalary()
        {
            var s=await _unit.job.GetThirdHighestSalary();

            return Ok(s);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdWithDetails(int id)
        {
            var jobs = await _unit.job.GetAllDetailsWithCompany();
            var dto = jobs.Select(x => new
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Salary = x.Salary,
                EmploymentType = x.EmploymentType,
                Location = x.Location,
                Status = x.Status,
                CompanyName = x.Company.Name,
                CompanyDescription=x.Company.Description,
                CompanyLocation=x.Company.Location,
                CompanyWebSite=x.Company.Website

            }).ToList();
            var job=dto.FirstOrDefault(x=>x.Id==id);
            if (job == null) { return NotFound("Job Doesnot exeist"); }

            return Ok(job);
        }


        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var j = await _unit.job.GetById(id);
            if (j == null) { return NotFound("Job Doesnot exeist"); }

            _unit.job.Delete(j);
            _unit.Save();
            return NoContent(); 
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string word)
        {
            var j=await _unit.job.Search(word);

            var dto = j.Select(x => new
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Salary = x.Salary,
                EmploymentType = x.EmploymentType,
                Location = x.Location,
                Status = x.Status

            }).ToList();

            return Ok(dto);

        }
    }
}
