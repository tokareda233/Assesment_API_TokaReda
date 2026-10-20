using Assesment_API_TokaReda.Data;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assesment_API_TokaReda.Repos.Implmentation
{
    public class CompanyRepo : GenericRepo<Company>, ICompanyRepo
    {
        private readonly AppDbContext _context;
        public CompanyRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Company> GetTheMostPublishedCompany()
        {
            return await _context.companies.Include(x => x.Jobs).OrderByDescending(c => c.Jobs.Count()).FirstOrDefaultAsync();
        }
    }
}
