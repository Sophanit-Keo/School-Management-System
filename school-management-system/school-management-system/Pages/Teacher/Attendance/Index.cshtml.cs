using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;


namespace school_management_system.Pages.Teacher.Attendance
{
    public class IndexModel(AppDBContext _db) : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? SelectedGroupId { get; set; }

        [BindProperty]
        public List<StudentAttendanceInput> StudentsAttendance { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? SelectedSubjectId { get; set; }

        public class StudentAttendanceInput
        {
            public int StudentId { get; set; }
            public string Status { get; set; }
        }

        public List<GroupModel> Groups { get; set; } = new();
        public List<StudentModel> Students { get; set; } = new();
        public List<SubjectModel> Subjects { get; set; } = new();


        public int PresentCount { get; set; }
        public int AbsentCount { get; set; }
        public int LateCount { get; set; }
        public int TotalCount { get; set; }

        public enum AttendanceStatus
        {
            Present = 1,
            Absent = 2,
            Late = 3
        }


        public void OnGet()
        {
            // Load available groups
            Groups = _db.Groups.ToList();
            Subjects = _db.Subjects.ToList();


            // If a group is selected, load students from Enrollments
            if (SelectedGroupId.HasValue && SelectedGroupId.Value > 0)
            {
                Students = _db.Enrollments
                    .Where(e => e.GroupId == SelectedGroupId)
                    .Include(e => e.Student)
                        .ThenInclude(s => s.Attendances)
                    .Select(e => e.Student)
                    .ToList();

                // Summary counts
                TotalCount = Students.Count;
                PresentCount = Students.Count(s => s.Attendances.Any(a =>
                    a.GroupId == SelectedGroupId &&
                    a.AttendanceDate == DateOnly.FromDateTime(DateTime.Today) &&
                    a.Status == 1));
                AbsentCount = Students.Count(s => s.Attendances.Any(a =>
                    a.GroupId == SelectedGroupId &&
                    a.AttendanceDate == DateOnly.FromDateTime(DateTime.Today) &&
                    a.Status == 2));
                LateCount = Students.Count(s => s.Attendances.Any(a =>
                    a.GroupId == SelectedGroupId &&
                    a.AttendanceDate == DateOnly.FromDateTime(DateTime.Today) &&
                    a.Status == 3));
            }
        }

        public IActionResult OnPostSaveAttendance()
        {
            if (StudentsAttendance == null || !StudentsAttendance.Any() || !SelectedGroupId.HasValue || !SelectedSubjectId.HasValue)
                return Page(); // stop if group or subject not selected

            foreach (var s in StudentsAttendance)
            {
                int statusInt = s.Status switch
                {
                    "Present" => 1,
                    "Absent" => 2,
                    "Late" => 3,
                    _ => 0
                };

                var attendance = new AttendanceModel
                {
                    StudentId = s.StudentId,
                    Status = statusInt,
                    GroupId = SelectedGroupId.Value,
                    SubjectId = SelectedSubjectId.Value,
                    AttendanceDate = DateOnly.FromDateTime(DateTime.Today)
                };

                _db.Attendances.Add(attendance);
            }

            _db.SaveChanges();
            Console.WriteLine("DEBUG: Saved to DB.");
            return RedirectToPage(new { SelectedGroupId = SelectedGroupId, SelectedSubjectId = SelectedSubjectId });
        }

    }
}
