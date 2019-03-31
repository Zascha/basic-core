using WebApplication.Data.Models;

namespace WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);

        bool IsAdmin(string login);

        int CreateUser(User user);

        void UpdateUser(User user);

        void RemoveUser(int id);
    }
}
