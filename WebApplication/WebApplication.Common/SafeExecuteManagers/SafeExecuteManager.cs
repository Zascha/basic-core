using System;
using System.Threading.Tasks;
using WebApplication.Common.Logger;

namespace WebApplication.Common.SafeExecuteManagers
{
    public class SafeExecuteManager : ISafeExecuteManager
    {
        private readonly ILogger _logger;

        public SafeExecuteManager(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void ExecuteWithExceptionLogging(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                _logger.LogError($"{action.Method.Name}() finished with exception.", exception);
            }
        }

        // TODO: implement result returning
        public void ExecuteWithExceptionLogging(Func<Task> func)
        {
            try
            {
                func().Wait();
            }
            catch (Exception exception)
            {
                _logger.LogError($"{func.Method.Name}() finished with exception.", exception);
            }
        }
    }
}
