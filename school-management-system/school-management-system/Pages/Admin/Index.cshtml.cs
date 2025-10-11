using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class IndexModel(AppDBContext _db) : PageModel
    {
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
        public async Task OnGet()
        {
            Teachers = await _db.Teachers
                .Include(t => t.Subjects)
                .ToListAsync();
            Students = await _db.Students
                .Include(s => s.Guardians)
                .ToListAsync();
            Groups = await _db.Groups.ToListAsync();
        }
        public int newStudent()
        {
            var oneYearAgo = DateTime.Now.AddYears(-1);
            return Students.Count(s => s.StartDate >= oneYearAgo);
        }
        public int newTeacher()
        {
            var oneYearAgo = DateTime.Now.AddYears(-1);
            return Teachers.Count(s => s.HireDate >= oneYearAgo);
        }
    }
}
