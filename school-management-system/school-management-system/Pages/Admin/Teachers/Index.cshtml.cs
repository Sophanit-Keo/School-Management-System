using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Teachers
{
    public class IndexModel(AppDBContext _db, UserManager<IdentityUser> _userManager) : PageModel
    {
        public UserManager<IdentityUser> UserManager { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public string Password { get; set; } = "Abc!@#456";
        public async Task OnGet()
        {
            Teachers = await _db.Teachers
                .Include(t => t.Subjects)
                .Include(t => t.TeacherUsers)
                .ToListAsync();
        }
    }
}
