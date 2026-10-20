using Assesment_API_TokaReda.Models;

namespace Assesment_API_TokaReda.Repos.Interfaces
{
    public interface IJobRepo:IGenericRepo<Job>
    {
        Task<Job> GetByIdDetailsWithCompany(int id);
        Task<List<Job>> GetAllDetailsWithCompany();

        Task<List<Job>> Search(string word);

        Task<decimal> GetThirdHighestSalary();
    }
}
