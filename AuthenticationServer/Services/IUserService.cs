using AuthenticationServer.Models;
using System.Threading.Tasks;

namespace AuthenticationServer.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}