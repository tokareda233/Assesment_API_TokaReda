using Assesment_API_TokaReda.Data;
using Assesment_API_TokaReda.DTOs.Auth;

namespace Assesment_API_TokaReda.Repos.Interfaces
{
    public interface IAuthRepo
    {
        Task<string> Login(LoginDTO dto);
        Task<bool> Register(RegisterDTO dto);

    }
}
