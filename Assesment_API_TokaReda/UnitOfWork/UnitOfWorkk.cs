using Assesment_API_TokaReda.Data;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.Repos.Interfaces;

namespace Assesment_API_TokaReda.UnitOfWork
{
    public class UnitOfWorkk : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IAuthRepo authRepo { get; }

        public IGenericRepo<User> user {  get; }

        public IJobRepo job {  get; }

        public ICompanyRepo company {  get; }

        public IApplicationRepo application {  get; }

        public IGenericRepo<CandidateProfile> CandidateProfile {  get; }

        public UnitOfWorkk(AppDbContext context,IAuthRepo Auth, IGenericRepo<User> use,IJobRepo j,ICompanyRepo COMP,IApplicationRepo APP, IGenericRepo<CandidateProfile> candi)
        {
            _context = context;
            authRepo = Auth;
            user = use;
            job = j;
            company=COMP;
            application = APP;
            CandidateProfile=candi;
        }

      

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
