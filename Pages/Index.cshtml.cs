using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using VoortgangBepalen.Services;
using VoortgangBepalen.ViewModels;


namespace VoortgangBepalen.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProgressBarService _service;

        public IndexModel(ProgressBarService service)
        {
            _service = service;
        }

        [BindProperty]
        [Required(ErrorMessage = "Naam is verplicht")]
        public string? TaskName { get; set; }

        [BindProperty]
        [Range(1, 100, ErrorMessage = "Voer een waarde in tussen 1 en 100")]
        public int TargetValue { get; set; }
        public List<ProgressBarViewModel> ProgressBars { get; set; } = new();
/*
        public void OnGet()
        {
            ProgressBars = _service.GetAllTasks()
                .Select(t => new ProgressBarViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Progress = t.Progress,
                    IsRunning = t.IsRunning
                }).ToList();
        }*/

        public JsonResult OnGetProgress()
        {
            var bars = _service.GetAllTasks()
                .Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.Progress,
                    t.IsRunning
                });
            return new JsonResult(bars);
        }

        public IActionResult OnPost()
        {
            _service.StartNewTask(TaskName ?? "New task", TargetValue);

            return RedirectToPage();
        }
    }
}
