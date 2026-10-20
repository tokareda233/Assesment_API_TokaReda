using Assesment_API_TokaReda.Models;

namespace Assesment_API_TokaReda.Repos.Interfaces
{
    public interface ICompanyRepo:IGenericRepo<Company>
    {

        Task<Company> GetTheMostPublishedCompany();
    }
}
