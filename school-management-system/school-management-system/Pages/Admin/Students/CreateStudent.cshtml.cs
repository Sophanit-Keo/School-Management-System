using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using school_management_system.Models;
namespace school_management_system.Pages.Admin.Students
{
    public class CreateStudentModel(AppDBContext _db) : PageModel
    {
        // StudentModel
        [BindProperty]
        public StudentModel Student { get; set; }
        [BindProperty]
        public IEnumerable<StudentModel> Students { get; set; }


        //RoleModel
        public RoleModel Role { get; set; }


        // GradeModel
        public GradeModel Grade { get; set; }
        public SelectList SelectListGrades { get; set; }
        [BindProperty]
        public int SelectedGrade { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }

        // GuardianModel
        [BindProperty]
        public GuardianModel Guardian { get; set; }
        public IEnumerable<GuardianModel> Guardians { get; set; }

        // Auth
        public AuthModel Auth { get; set; }
        public IEnumerable<AuthModel> Auths { get; set; }

        public async Task OnGet()
        {
        }

    }
}
