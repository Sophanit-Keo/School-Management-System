using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Classes
{
    public class AddClassModel(AppDBContext _db) : PageModel
    {
        // Group
        [BindProperty]
        public GroupModel Group { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
        public SelectList ListGroups { get; set; }
        [BindProperty]
        public int SelectedGroup { get; set; }
        // Subject 
        public IEnumerable<SubjectModel> Subjects { get; set; }
        public SelectList ListSubject { get; set; }
        [BindProperty]
        public int SelectedSubject { get; set; }

        // Teacher
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public SelectList ListTeacher { get; set; }
        [BindProperty]
        public int SelectedTeacher { get; set; }

        // Classroom
        [BindProperty]
        public ClassroomModel Classroom { get; set; }
        public SelectList ListClassroom { get; set; }
        public IEnumerable<ClassroomModel> Classrooms { get; set; }
        [BindProperty]
        public int SelectedClassroom { get; set; }

        //Timetable
        [BindProperty]
        public TimetableModel Timetable { get; set; }

        public IEnumerable<TimetableModel> FilteredTimetables { get; set; }
        public async Task OnGet()
        {
            Groups = await _db.Groups.ToListAsync();
            ListGroups = new SelectList(Groups, nameof(GroupModel.Id), nameof(GroupModel.Name));

            Subjects = await _db.Subjects.ToListAsync();
            ListSubject = new SelectList(Subjects, nameof(SubjectModel.Id), nameof(SubjectModel.Name));

            Teachers = await _db.Teachers.ToListAsync();
            ListTeacher = new SelectList(Teachers, nameof(TeacherModel.Id), nameof(TeacherModel.FirstName));

            Classrooms = await _db.Classrooms.ToListAsync();
            ListClassroom = new SelectList(Classrooms, nameof(ClassroomModel.Id), nameof(ClassroomModel.Name));

            Console.WriteLine($"SelectedGroup ID: {SelectedGroup}");

        }

        public async Task<IActionResult> OnPostAddGroup()
        {
            await _db.Groups.AddAsync(Group);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddRoom()
        {
            await _db.Classrooms.AddAsync(Classroom);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddClass()
        {
            ModelState.Remove("Name");
            ModelState.Remove("Homeworks");
            ModelState.Remove("Enrollments");
            ModelState.Remove("Enrollments");
            ModelState.Remove("Classroom.Timetables");
            ModelState.Remove("Timetable.Group");
            ModelState.Remove("Timetable.Subject");
            ModelState.Remove("Timetable.Teacher");
            ModelState.Remove("Timetable.Classroom");
            ModelState.Remove("Timetables");
            ModelState.Remove("Attendances");

            if (ModelState.IsValid)
            {

                if (SelectedGroup == 0)
                {
                    ModelState.AddModelError("SelectedGroup", "Please select a valid group.");
                }
                await _db.SaveChangesAsync();
                Console.WriteLine($"SelectedGroup ID: {SelectedGroup}");
                Console.WriteLine($"SelectedSubject ID: {SelectedSubject}");
                Console.WriteLine($"SelectedTeacher ID: {SelectedTeacher}");
                Console.WriteLine($"SelectedClassroom ID: {Classroom.Id}");
                var newTimetable = new TimetableModel
                {
                    DayOfWeek = Timetable.DayOfWeek,
                    StartTime = Timetable.StartTime,
                    EndTime = Timetable.EndTime,
                    GroupId = SelectedGroup,// Can not defind groupID
                    TeacherId = SelectedTeacher, // fix typo below
                    ClassroomId = SelectedClassroom,
                    SubjectId = SelectedSubject
                };

                Console.WriteLine(newTimetable);

                await _db.Timetables.AddAsync(newTimetable);
                await _db.SaveChangesAsync();

                return RedirectToPage();
            }
            else
            {
                Console.WriteLine(ModelState.ValidationState);
                foreach (var kvp in ModelState)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.ValidationState}");
                }
                return RedirectToPage();
            }
        }

    }
}
