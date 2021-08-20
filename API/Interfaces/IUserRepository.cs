using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Add(UserViewModel user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        void Delete(User user);
        Task<bool> SaveAllAsync();
        void Update(UserViewModel updatedUser, int id);
    }
}