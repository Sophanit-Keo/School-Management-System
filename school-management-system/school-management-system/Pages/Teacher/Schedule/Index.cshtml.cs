using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Teacher.Schedule
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _db;

        public IndexModel(AppDBContext db)
        {
            _db = db;
        }

        public List<TimetableModel> Timetables { get; set; } = new();

        public void OnGet()
        {
            // Load all timetables or filter by teacher if needed
            Timetables = _db.Timetables
                .Include(t => t.Group)
                .Include(t => t.Subject)
                .Include(t => t.Classroom)
                .OrderBy(t => t.DayOfWeek)
                .ThenBy(t => t.StartTime)
                .ToList();
        }
    }
}
