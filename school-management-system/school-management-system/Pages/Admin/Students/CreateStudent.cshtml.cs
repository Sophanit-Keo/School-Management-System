using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public SelectList SelectListGroup { get; set; }


        // GuardianModel
        [BindProperty]
        public GuardianModel Guardian { get; set; }
        public IEnumerable<GuardianModel> Guardians { get; set; }

        // Group


        public async Task OnGet()
        {
            Students = await _db.Students
                    .Include(s => s.Guardians)
                    .ToListAsync();
        }
        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Student.Attendances");
            ModelState.Remove("Student.Grades");
            ModelState.Remove("Student.Guardians");
            ModelState.Remove("Student.Enrollments");
            ModelState.Remove("Student.HomeworkSubmissions");
            ModelState.Remove("Guardian.Students");
            if (ModelState.IsValid)
            {
                Console.WriteLine("Valide");
                await _db.Guardians.AddAsync(Guardian);
                await _db.SaveChangesAsync();
                Student.Guardians = [];
                var sGuardian = await _db.Guardians.FindAsync(Guardian.Id);
                Student.Guardians.Add(sGuardian);
                await _db.Students.AddAsync(Student);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
