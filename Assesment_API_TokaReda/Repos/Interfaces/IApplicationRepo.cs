using Assesment_API_TokaReda.Models;

namespace Assesment_API_TokaReda.Repos.Interfaces
{
    public interface IApplicationRepo:IGenericRepo<Application>
    {
        Task<List<Application>> AppsSubmittedByCandidate(int candidateId);
     }
}
