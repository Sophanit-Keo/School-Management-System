using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;


namespace school_management_system.Pages.Teacher.Attendance
{
    public class IndexModel(AppDBContext _db) : PageModel
    {
        [BindProperty]
        public StudentModel Student { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public async Task OnGet()
        {
            Students = await _db.Students.ToListAsync();
        }

    }

}
