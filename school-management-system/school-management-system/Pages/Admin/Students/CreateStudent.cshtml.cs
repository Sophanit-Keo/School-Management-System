using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;
namespace school_management_system.Pages.Admin.Students
{
    public class CreateStudentModel(AppDBContext _db, UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager) : PageModel
    {
        // StudentModel
        [BindProperty]
        public StudentModel Student { get; set; }
        [BindProperty]
        public IEnumerable<StudentModel> Students { get; set; }



        // GuardianModel
        [BindProperty]
        public GuardianModel Guardian { get; set; }
        public IEnumerable<GuardianModel> Guardians { get; set; }


        // Group
        public SelectList ListGroups { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
        [BindProperty]
        public int SelectedGroup { get; set; }

        public async Task OnGet()
        {
            Groups = await _db.Groups.ToListAsync();
            ListGroups = new SelectList(Groups, nameof(GroupModel.Id), nameof(GroupModel.Name));

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
                // Add Student
                await _db.Students.AddAsync(Student);
                await _db.SaveChangesAsync();

                // Enrollment
                var enroll = new EnrollmentModel
                {
                    GroupId = SelectedGroup,
                    StudentId = Student.Id,
                    EnrollmentDate = DateOnly.FromDateTime(DateTime.Now),
                };
                await _db.Enrollments.AddAsync(enroll);
                await _db.SaveChangesAsync();

                var autoPassword = "Abc!@#456";
                var autoEmail = $"{Student.FirstName.ToLower()}.{Student.LastName.ToLower()}.{Student.Id}@school.edu.kh";

                //Auth for student
                /*
                 {
                    Username: ST_{StudentFirstNem}{ID}
                    Password: Auto generated
                 }
                */
                var user = new IdentityUser
                {
                    UserName = autoEmail,
                    Email = autoEmail,
                };

                var result = await _userManager.CreateAsync(user, autoPassword);
                Student.UserId = user.Id;
                await _db.SaveChangesAsync();
                Console.WriteLine(autoPassword);



                if (result.Succeeded)
                {
                    Console.WriteLine(Student.Id);
                    await _userManager.AddToRoleAsync(user, "student");
                    var roles = await _userManager.GetRolesAsync(user);
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    Console.WriteLine("Roles: " + string.Join(", ", roles));
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return Page();

        }

    }
}
