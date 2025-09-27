using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Students
{

    public class EditStudentModel(AppDBContext _db) : PageModel
    {
        // StudentModel
        [BindProperty]
        public StudentModel Student { get; set; }


        //RoleModel
        //public SelectList SelectListGroup { get; set; }


        // GuardianModel
        [BindProperty]
        public GuardianModel Guardian { get; set; }


        // Group
        public async Task OnGet(int studentId)
        {
            studentId = 1;
            Student = await _db.Students
                .Include(s => s.Guardians)
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Student.Attendances");
            ModelState.Remove("Student.Grades");
            ModelState.Remove("Student.Guardians");
            ModelState.Remove("Student.Enrollments");
            ModelState.Remove("Student.HomeworkSubmissions");
            ModelState.Remove("Guardian.Students");
            ModelState.Remove("Student.StudentUsers");

            if (!ModelState.IsValid)
                return Page();

            var existingStudent = await _db.Students
                .Include(s => s.Guardians)
                .FirstOrDefaultAsync(s => s.Id == Student.Id);

            if (existingStudent == null)
                return NotFound();

            // Update basic student fields
            existingStudent.FirstName = Student.FirstName;
            existingStudent.LastName = Student.LastName;
            existingStudent.Email = Student.Email;
            existingStudent.Phone = Student.Phone;
            existingStudent.DOB = Student.DOB;
            existingStudent.Gender = Student.Gender;
            existingStudent.StartDate = Student.StartDate;
            existingStudent.Status = Student.Status;
            existingStudent.Address = Student.Address;
            existingStudent.SpecialRequirements = Student.SpecialRequirements;

            // Update guardian (replace or update existing)
            existingStudent.Guardians = [];
            existingStudent.Guardians.Add(Guardian);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }


    }
}
