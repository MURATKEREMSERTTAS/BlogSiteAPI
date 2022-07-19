using BlogSiteAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> GetUser(string id);

        Task CreateUser(User user);

        Task UpdateUser(string id, User updateUser);

        Task DeleteUser(string id);
    }
}
