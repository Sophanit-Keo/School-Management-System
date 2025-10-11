using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Students
{

    public class EditStudentModel(AppDBContext _db) : PageModel
    {
        // StudentModel
        [BindProperty]
        public StudentModel Student { get; set; }

        // Group
        public SelectList ListGroups { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
        [BindProperty]
        public int SelectedGroup { get; set; }
        public async Task<IActionResult> OnGet(int studentId)
        {
            Groups = await _db.Groups.ToListAsync();
            ListGroups = new SelectList(Groups, nameof(GroupModel.Id), nameof(GroupModel.Name));
            Student = await _db.Students
                .Include(s => s.Guardians)
                .Include(s => s.Enrollments)
                .FirstOrDefaultAsync(s => s.Id == studentId);
            SelectedGroup = Student.Enrollments.FirstOrDefault()?.GroupId ?? 0;
            if (Student == null)
                return NotFound();

            return Page();
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
            {
                Student = await _db.Students
                    .Include(s => s.Guardians)
                    .FirstOrDefaultAsync(s => s.Id == Student.Id);

                foreach (var kvp in ModelState)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.ValidationState}");
                }
                return Page();
            }

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
            var enr = new EnrollmentModel
            {
                EnrollmentDate = DateOnly.FromDateTime(DateTime.UtcNow),
                GroupId = SelectedGroup,
                StudentId = existingStudent.Id,
            };
            await _db.Enrollments.AddAsync(enr);
            // Update guardian information
            var submittedGuardian = Student.Guardians?.FirstOrDefault();
            if (submittedGuardian != null)
            {
                var existingGuardian = existingStudent.Guardians.FirstOrDefault();

                if (existingGuardian != null)
                {
                    // Update existing guardian
                    existingGuardian.FirstName = submittedGuardian.FirstName;
                    existingGuardian.LastName = submittedGuardian.LastName;
                    existingGuardian.Phone = submittedGuardian.Phone;
                }
                else
                {
                    // Add new guardian if none exists
                    existingStudent.Guardians.Add(submittedGuardian);
                }
            }

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }


    }
}
