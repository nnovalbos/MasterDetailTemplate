using System;
using System.Threading.Tasks;

namespace MasterDetailTemplate.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(string userName, string password);
    }
}
