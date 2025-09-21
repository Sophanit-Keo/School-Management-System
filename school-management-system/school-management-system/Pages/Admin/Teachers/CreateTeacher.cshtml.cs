
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;
using school_management_system.Models.Users;

namespace school_management_system.Pages.Admin.Teachers
{
    public class CreateTeacherModel(AppDBContext _db, UserManager<IdentityUser> _userManager) : PageModel
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
                var autoPassword = PasswordGenderator.GeneratePassword(7);
                var autoUsername = $"T_{Teacher.FirstName}{Teacher.LastName}{Teacher.Id}";

                //var fstudent = await _db.Students.FindAsync(Student.Id);
                //var autoPassword = PasswordGenderator.GeneratePassword(8);
                //var autoUsername = $"ST_{Student.FirstName}{Student.Id}";

                //Auth for Teacher
                /*
                 {
                    Username: ST_{TeacherFirstName}{Teacher.LastName}{ID}
                    Password: Auto generated
                 }
                */

                var teacherUser = new UserEntity()
                {
                    TeacherId = fTeacher.Id,
                    UserName = autoUsername,
                    Email = $"{Teacher.FirstName.ToLower()}.{Teacher.LastName}@school.edu.kh"
                };
                var result = await _userManager.CreateAsync(teacherUser, autoPassword);
                if (result.Succeeded)
                {
                    Console.WriteLine(fTeacher.Id);

                    await _userManager.AddToRoleAsync(teacherUser, "teacher");
                    return RedirectToPage("Index");
                }

                // Show Identity errors
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }
        }
    }
}
