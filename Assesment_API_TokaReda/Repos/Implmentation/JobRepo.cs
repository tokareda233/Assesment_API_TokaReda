using System.Reflection.Metadata.Ecma335;
using Assesment_API_TokaReda.Data;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assesment_API_TokaReda.Repos.Implmentation
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {
        private readonly AppDbContext _context;
        public JobRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Job>> GetAllDetailsWithCompany()
        {
            return await _context.jobs.Include(c => c.Company).ToListAsync();
        }

        public async Task<Job> GetByIdDetailsWithCompany(int id)
        {
            return await _context.jobs.Include(c => c.Company).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<decimal> GetThirdHighestSalary()
        {
           var j= await _context.jobs
                 .Select(c => c.Salary)
                 .Distinct()
                 .OrderByDescending(s => s)
                 .Skip(2)
                 .FirstOrDefaultAsync();


            return j;
        }

        public async Task<List<Job>> Search(string word)
        {
           return await _context.jobs.Where(c=>c.Title.Contains(word)||c.Description.Contains(word)).ToListAsync();
        }
    }
}
