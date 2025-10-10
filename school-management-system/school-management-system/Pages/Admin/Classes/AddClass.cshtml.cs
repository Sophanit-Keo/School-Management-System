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
        public int SelectedGroup { get; set; }
        // Subject 
        public IEnumerable<SubjectModel> Subjects { get; set; }
        public SelectList ListSubject { get; set; }
        public int SelectedSubject { get; set; }

        // Teacher
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public SelectList ListTeacher { get; set; }
        public int SeletedTeacher { get; set; }

        // Classroom
        [BindProperty]
        public ClassroomModel Classroom { get; set; }

        //Timetable
        public TimetableModel Timetable { get; set; }
        public async Task OnGet()
        {
            Groups = await _db.Groups.ToListAsync();
            ListGroups = new SelectList(Groups, nameof(GroupModel.Id), nameof(GroupModel.Name));

            Subjects = await _db.Subjects.ToListAsync();
            ListSubject = new SelectList(Subjects, nameof(SubjectModel.Id), nameof(SubjectModel.Name));

            Teachers = await _db.Teachers.ToListAsync();
            ListTeacher = new SelectList(Teachers, nameof(TeacherModel.Id), nameof(TeacherModel.FirstName));
        }
        public async Task<IActionResult> OnPostAddGroup()
        {
            await _db.Groups.AddAsync(Group);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddClass()
        {
            await _db.Classrooms.AddAsync(Classroom);
            var timetable = new TimetableModel
            {
                DayOfWeek = Timetable.DayOfWeek,
                StartTime = Timetable.StartTime,
                EndTime = Timetable.EndTime,
                GroupId = SelectedGroup,
                TeacherId = SeletedTeacher,
                ClassroomId = Classroom.Id,
                SubjectId = SelectedSubject
            };
            await _db.Timetables.AddAsync(timetable);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
