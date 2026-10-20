using Assesment_API_TokaReda.Data;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assesment_API_TokaReda.Repos.Implmentation
{
    public class ApplicationRepo : GenericRepo<Application>, IApplicationRepo
    {
        private readonly AppDbContext _context;
        public ApplicationRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Application>> AppsSubmittedByCandidate(int candidateId)
        {
            return await _context.applications.Include(c=>c.CandidateProfile).Where(c=>c.CandidateProfile.CadidateId==candidateId).ToListAsync();
        }
    }
}
