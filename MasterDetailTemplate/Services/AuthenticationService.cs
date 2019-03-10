using System;
using System.Threading.Tasks;
using MasterDetailTemplate.Contracts.Services;

namespace MasterDetailTemplate.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<string> Authenticate(string userName, string password)
        {
            //We simulate waiting time for a request to a service
            await Task.Delay(2000);
            return "Token2323";
        }
    }
}
