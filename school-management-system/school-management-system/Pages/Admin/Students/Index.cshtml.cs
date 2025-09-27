using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Students
{
    public class IndexModel(AppDBContext _db, UserManager<IdentityUser> _userManager) : PageModel
    {

        public string NoGroup { get; set; } = "No gorup yet";
        public string Password { get; set; } = "Abc!@#456";
        // StudentModel
        public StudentModel Student { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }


        public async Task OnGet()
        {
            Students = await _db.Students
                .Include(s => s.Guardians)
                .Include(s => s.StudentUsers)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Group)
                .ToListAsync();

        }
    }
}
