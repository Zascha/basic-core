using WebApplication.Data.Models;
using WebApplication.DataAccess.GenericRepository;

namespace WebApplication.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckIsAdminByLogin(string login);
    }
}
