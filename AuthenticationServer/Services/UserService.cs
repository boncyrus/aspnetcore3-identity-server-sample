using AuthenticationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationServer.Services
{
    public class UserService : IUserService
    {
        private IList<User> _users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = "bob",
                Password = "bob"
            }
        };

        public Task<User> Authenticate(string username, string password)
        {
            var user = _users.FirstOrDefault(x => x.Username == username && x.Password == password);
            return Task.FromResult(user);
        }
    }
}