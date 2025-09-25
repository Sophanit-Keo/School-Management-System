using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Users
{
    public class IndexModel(AppDBContext _db) : PageModel
    {
        public string Password { get; set; } = "Abc!@#456";
        public TeacherModel Teacher { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public StudentModel Student { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public async Task OnGet()
        {
            Teachers = await _db.Teachers
                .Include(t => t.TeacherUsers)
                .ToListAsync();
            Students = await _db.Students
                .Include(t => t.StudentUsers)
                .ToListAsync();
        }
    }
}
