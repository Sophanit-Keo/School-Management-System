using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;
using school_management_system.Models.Users;

namespace school_management_system.Pages.Student
{
    public class IndexModel(AppDBContext _db, UserManager<StudentUser> _userManager) : PageModel
    {
        public StudentModel Student { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            Console.WriteLine("Fail");
            if (user == null)
            {
                return Unauthorized();
            }
            Student = await _db.Students
                .FirstOrDefaultAsync(s => s.Id == user.StudentId);
            return Page();
        }
    }
}
