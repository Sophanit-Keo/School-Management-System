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
        public SelectList SelectListGrades { get; set; }


        // GuardianModel
        [BindProperty]
        public GuardianModel Guardian { get; set; }
        public IEnumerable<GuardianModel> Guardians { get; set; }


        public async Task OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Student.Auths");
            ModelState.Remove("Student.Grade");
            ModelState.Remove("Student.Guardians");
            ModelState.Remove("Guardian.Students");
            if (ModelState.IsValid)
            {


                // 5. Redirect
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
