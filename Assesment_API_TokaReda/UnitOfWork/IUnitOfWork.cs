using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.Repos.Interfaces;

namespace Assesment_API_TokaReda.UnitOfWork
{
    public interface IUnitOfWork
    {
        // test pull
        IAuthRepo authRepo { get; }
        IGenericRepo<User> user {  get; }
        IGenericRepo<CandidateProfile> CandidateProfile { get; }
        ICompanyRepo company { get; }
        IApplicationRepo application { get; }

        IJobRepo job { get; }
        void Save();
    }
}
