using System;
using WebApplication.Common.SafeExecuteManagers;
using WebApplication.Data.Models;
using WebApplication.DataAccess.Interfaces;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services.Services
{
    public class UserService : IUserService
    {
        public ISafeExecuteManager _safeExecuteManager;
        public IUserRepository _userRepository;

        public UserService(
            ISafeExecuteManager safeExecuteManager,
            IUserRepository userRepository)
        {
            _safeExecuteManager = safeExecuteManager ?? throw new ArgumentNullException(nameof(safeExecuteManager));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public bool IsAdmin(string login)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return _safeExecuteManager.ExecuteWithExceptionLogging(user, (u) =>
            {
                return _userRepository.Create(u);
            });
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _safeExecuteManager.ExecuteWithExceptionLogging(() =>
            {
                _userRepository.Update(user);
            });
        }

        public void RemoveUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Negative id value");
            }

            _safeExecuteManager.ExecuteWithExceptionLogging(() =>
            {
                _userRepository.Remove(id);
            });
        }
    }
}
