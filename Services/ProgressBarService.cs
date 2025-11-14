using System.Collections.Concurrent;
using VoortgangBepalen.Models;

namespace VoortgangBepalen.Services
{
    public class ProgressBarService
    {
        private readonly ConcurrentDictionary<Guid, ProgressBar> _tasks = new();

        public IEnumerable<ProgressBar> GetAllTasks() => _tasks.Values;

        public ProgressBar StartNewTask(string name, int targetValue)
        {
            if (targetValue < 1 || targetValue > 100)
                throw new ArgumentOutOfRangeException(nameof(targetValue), "Value must be between 1 and 100.");

            var task = new ProgressBar { Name = name };
            task.Start();
            _tasks[task.Id] = task;

            double totalSeconds = targetValue * 60;
            double delayInMilliSeconds = (totalSeconds / 100) * 1000;

            Task.Run(async () =>
            {
                while (task.Progress < 100)
                {
                    await Task.Delay((int)delayInMilliSeconds);
                    task.UpdateProgress(task.Progress + 1);
                }
            });

            return task;
        }

        public ProgressBar? GetTask(Guid id)
        {
            _tasks.TryGetValue(id, out var task);
            return task;
        }
    }
}
