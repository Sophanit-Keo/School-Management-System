using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Students
{
    public class IndexModel(AppDBContext _db) : PageModel
    {

        // StudentModel
        public StudentModel Student { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }


        //RoleModel


        // GradeModel

        // GuardianModel

        // Auth

        public async Task OnGet()
        {
            Students = await _db.Students
                .Include(s => s.Guardians)
                .ToListAsync();
        }
    }
}
