using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;
using school_management_system.Models.Users;
namespace school_management_system.Pages.Admin.Students
{
    public class CreateStudentModel(AppDBContext _db, UserManager<IdentityUser> _userManager) : PageModel
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
            ModelState.Remove("Student.StudentUsers");
            if (ModelState.IsValid)
            {
                // Pass
                await _db.Guardians.AddAsync(Guardian);
                await _db.SaveChangesAsync();
                Student.Guardians = [];
                var sGuardian = await _db.Guardians.FindAsync(Guardian.Id);
                Student.Guardians.Add(sGuardian);
                await _db.Students.AddAsync(Student);
                await _db.SaveChangesAsync();

                var fstudent = await _db.Students.FindAsync(Student.Id);
                var autoPassword = PasswordGenderator.GeneratePassword(8);
                var autoUsername = $"ST_{fstudent.FirstName}{fstudent.Id}";

                //Auth for student
                /*
                 {
                    Username: ST_{StudentFirstNem}{ID}
                    Password: Auto generated
                 }
                */
                var user = new StudentUser
                {

                    UserName = autoUsername,
                    Email = $"{fstudent.FirstName}_{fstudent.LastName}@school.edu.kh",
                    StudentId = fstudent.Id,
                };

                var result = await _userManager.CreateAsync(user, autoPassword);
                Console.WriteLine(user.UserName);

                Console.WriteLine(autoPassword);

                if (result.Succeeded)
                {
                    Console.WriteLine(fstudent.Id);
                    await _userManager.AddToRoleAsync(user, "student");
                    return RedirectToPage("Index");
                }

                // Show Identity errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }
        }

    }
}
