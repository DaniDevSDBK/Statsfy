using Statsfy.Services.ThreadsServices;

namespace Statsfy.Services.ApiServices
{
    public abstract class BaseApiService
    {
        private ThreadManager _threadManager = new ThreadManager();

        protected List<object> RunInBackgroundColor(params Func<object>[] methods) => 
            _threadManager.RunInBackgroundColor(methods).Result; 
    }
}
