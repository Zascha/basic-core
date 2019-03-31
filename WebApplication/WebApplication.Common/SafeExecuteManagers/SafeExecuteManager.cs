using System;
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
                throw;
            }
        }

        public ResultT ExecuteWithExceptionLogging<ArgT, ResultT>(ArgT arg, Func<ArgT, ResultT> func)
        {
            try
            {
                return func(arg);
            }
            catch (Exception exception)
            {
                _logger.LogError($"{func.Method.Name}() finished with exception.", exception);
                throw;
            }
        }
    }
}
