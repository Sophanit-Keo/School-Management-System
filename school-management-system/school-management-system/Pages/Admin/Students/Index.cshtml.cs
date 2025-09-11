using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IEnumerable<GradeModel> Grades { get; set; }

        // GuardianModel

        // Auth

        public async Task OnGet()
        {
        }
    }
}
