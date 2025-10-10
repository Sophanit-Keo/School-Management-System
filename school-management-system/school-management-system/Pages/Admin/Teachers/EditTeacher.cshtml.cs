using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Teachers
{
    public class EditTeacherModel(AppDBContext _db) : PageModel
    {
        [BindProperty]
        public TeacherModel Teacher { get; set; }

        public SelectList SubjectItems { get; set; }

        [BindProperty]
        public int SelectedSubject { get; set; }

        public IEnumerable<SubjectModel> Subjects { get; set; }

        public async Task<IActionResult> OnGet(int teacherId)
        {
            Teacher = await _db.Teachers
                .Include(t => t.Subjects)
                .FirstOrDefaultAsync(t => t.Id == teacherId);
            Console.WriteLine(Teacher.Id);
            if (Teacher == null)
            {
                return NotFound();
            }

            Subjects = await _db.Subjects.ToListAsync();
            SubjectItems = new SelectList(Subjects, nameof(SubjectModel.Id), nameof(SubjectModel.Name));
            if (Teacher.Subjects.Any())
            {
                SelectedSubject = Teacher.Subjects.First().Id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Teacher.Subjects");
            ModelState.Remove("Teacher.Timetables");
            ModelState.Remove("Teacher.Grades");
            ModelState.Remove("Teacher.Homeworks");
            ModelState.Remove("Teacher.TeacherUsers");
            ModelState.Remove("Subjects");
            ModelState.Remove("SubjectItems");

            if (!ModelState.IsValid)
            {
                Subjects = await _db.Subjects.ToListAsync();
                SubjectItems = new SelectList(Subjects, nameof(SubjectModel.Id), nameof(SubjectModel.Name));

                foreach (var kvp in ModelState)
                {
                    if (kvp.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value.ValidationState}");
                        foreach (var error in kvp.Value.Errors)
                        {
                            Console.WriteLine($"  Error: {error.ErrorMessage}");
                        }
                    }
                }
                return Page();
            }

            var existingTeacher = await _db.Teachers
                .Include(t => t.Subjects)
                .FirstOrDefaultAsync(t => t.Id == Teacher.Id);

            if (existingTeacher == null)
            {
                return NotFound();
            }

            // Update basic teacher fields
            existingTeacher.FirstName = Teacher.FirstName;
            existingTeacher.LastName = Teacher.LastName;
            existingTeacher.DOB = Teacher.DOB;
            existingTeacher.Email = Teacher.Email;
            existingTeacher.Phone = Teacher.Phone;
            existingTeacher.Gender = Teacher.Gender;
            existingTeacher.HireDate = Teacher.HireDate;
            existingTeacher.Status = Teacher.Status;

            // Update subject relationship
            existingTeacher.Subjects.Clear();
            var selectedSubject = await _db.Subjects.FindAsync(SelectedSubject);
            if (selectedSubject != null)
            {
                existingTeacher.Subjects.Add(selectedSubject);
            }

            try
            {
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch (DbUpdateException ex)
            {
                // Log the error
                Console.WriteLine($"Error updating teacher: {ex.Message}");

                // Reload the form
                Subjects = await _db.Subjects.ToListAsync();
                SubjectItems = new SelectList(Subjects, nameof(SubjectModel.Id), nameof(SubjectModel.Name));

                ModelState.AddModelError(string.Empty, "An error occurred while updating the teacher. Please try again.");
                return Page();
            }
        }
    }
}