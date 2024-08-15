namespace Statsfy.Services.ThreadsServices
{
    public class ThreadManager
    {
        public async Task<List<object>> RunInBackgroundColor(params Func<object>[] methods)
        {
            var tasks = new List<Task<object>>();

            foreach (var method in methods)
            {
                var task = Task.Run(() => method());
                tasks.Add(task);
            }

            var results = tasks.Select(task => task.Result).ToList();

            return results;
        }

        public async Task RunInBackgroundColor(params Action[] methods)
        {
            var tasks = new List<Task>();

            foreach (var method in methods)
            {
                var task = Task.Run(() => method());
                tasks.Add(task);
            }
        }
    }
}
