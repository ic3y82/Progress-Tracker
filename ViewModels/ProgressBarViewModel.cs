namespace VoortgangBepalen.ViewModels
{
    public class ProgressBarViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Progress { get; set; }
        public bool IsRunning { get; set; }
    }
}
