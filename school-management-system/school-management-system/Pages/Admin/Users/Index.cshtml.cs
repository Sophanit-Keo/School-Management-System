using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Users
{
    public class IndexModel(AppDBContext _db, UserManager<IdentityUser> _userManager) : PageModel
    {
        public string Password { get; set; } = "Abc!@#456";
        public TeacherModel Teacher { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public StudentModel Student { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }

        public List<IdentityUser> Users { get; set; }
        public async Task OnGet()
        {
            Teachers = await _db.Teachers
                .ToListAsync();
            Students = await _db.Students
                .ToListAsync();
            Users = await _userManager.Users.ToListAsync();
        }
    }
}
