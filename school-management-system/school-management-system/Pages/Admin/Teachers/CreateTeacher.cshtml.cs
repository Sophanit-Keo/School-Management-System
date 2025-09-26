
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;
using school_management_system.Models.Users;

namespace school_management_system.Pages.Admin.Teachers
{
    public class CreateTeacherModel(AppDBContext _db, UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager) : PageModel
    {
        // Teacher 
        [BindProperty]
        public TeacherModel Teacher { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }

        // Subject
        [BindProperty]
        public SubjectModel Subject { get; set; }
        public SelectList SubjectItems { get; set; }
        [BindProperty]
        public int SelectedSubject { get; set; }
        public IEnumerable<SubjectModel> Subjects { get; set; }

        public async Task OnGet()
        {
            Subjects = await _db.Subjects.ToListAsync();
            Teachers = await _db.Teachers
                .ToListAsync();
            SubjectItems = new SelectList(Subjects, nameof(SubjectModel.Id), nameof(SubjectModel.Name));
        }
        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Teacher.Gender");
            ModelState.Remove("Teacher.Timetables");
            ModelState.Remove("Teacher.Homeworks");
            ModelState.Remove("Teacher.Subjects");
            ModelState.Remove("Subjects");

            if (!ModelState.IsValid)
            {
                await _db.Teachers.AddAsync(Teacher);
                Teacher.Subjects = [];
                var sSubject = await _db.Subjects.FindAsync(SelectedSubject);
                Teacher.Subjects.Add(sSubject);
                await _db.Teachers.AddAsync(Teacher);
                await _db.SaveChangesAsync();

                var fTeacher = await _db.Teachers.FindAsync(Teacher.Id);
                var autoPassword = "Abc!@#456";
                var autoEmail = $"{fTeacher.FirstName.ToLower()}.{fTeacher.LastName.ToLower()}.{fTeacher.Id}@school.edu.kh";

                //Auth for Teacher
                /*
                 {
                    Username: FirstName.LastName.@school.edu.kh"
                    Password: "Abc!@#456"
                 }
                */

                var teacherUser = new TeacherUser()
                {
                    TeacherId = fTeacher.Id,
                    Email = autoEmail,
                    UserName = autoEmail,
                };

                var result = await _userManager.CreateAsync(teacherUser, autoPassword);

                Console.WriteLine(teacherUser.UserName);
                Console.WriteLine(autoPassword);
                if (result.Succeeded)
                {
                    Console.WriteLine(fTeacher.Id);
                    await _userManager.AddToRoleAsync(teacherUser, "teacher");
                    await _signInManager.SignInAsync(teacherUser, isPersistent: true);
                    var roles = await _userManager.GetRolesAsync(teacherUser);
                    Console.WriteLine("Roles: " + string.Join(", ", roles));
                    return RedirectToPage("Index");
                }

                // Show Identity errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return RedirectToPage("Index");

        }
    }
}
