namespace VoortgangBepalen.Models
{
    public class ProgressBar
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public DateTime StartTime { get; set; }
        public int Progress { get; set; } = 0;
        public bool IsRunning { get; set; } = false;
        public bool IsCompleted => Progress >= 100;

        public void Start()
        {
            IsRunning = true;
            StartTime = DateTime.Now;
        }

        public void UpdateProgress(int value)
        {
            Progress = Math.Clamp(value, 0, 100);
            if (Progress >= 100)
                IsRunning = false;
        }
    }
}
