using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication.Data.Models;
using WebApplication.DataAccess.GenericRepository;

namespace WebApplication.DataAccess.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool CheckIsAdminByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            using (_context)
            {
                var user = _context.Set<User>().FirstOrDefault(x => x.Login.Equals(login, StringComparison.Ordinal));

                return user != null && user.IsAdmin;
            }
        }
    }
}
