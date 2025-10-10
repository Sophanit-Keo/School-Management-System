using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Student
{
    public class IndexModel(AppDBContext _db, UserManager<IdentityUser> _userManager) : PageModel
    {
        public StudentModel Student { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public List<IdentityUser> Users { get; set; }
        public string UserId { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var loginUser = await _userManager.GetUserAsync(User);
            Students = await _db.Students.ToListAsync();
            Console.WriteLine("Fail");
            foreach (var student in Students)
            {
                if (loginUser.Id == student.UserId)
                {
                    Student = student;
                }
            }
            return Page();
        }
    }
}
