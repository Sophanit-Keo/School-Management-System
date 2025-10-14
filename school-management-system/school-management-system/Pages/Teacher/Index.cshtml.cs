using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Teacher
{
    public class TeacherDashboardModel(AppDBContext _db, UserManager<IdentityUser> _userManager) : PageModel
    {

        // Teacher Info
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int Rank { get; set; }
        public int ClassCount { get; set; }
        public double StudentProgress { get; set; }

        // Working Hours Summary
        public string TotalHours { get; set; } = "36h 00m";
        public string OnlineHours { get; set; } = "12h 00m";
        public string OfflineHours { get; set; } = "24h 00m";

        // Collections
        public List<WorkingHour> WorkingHours { get; set; } = new();
        public List<GroupChat> GroupChats { get; set; } = new();
        public List<StudentTest> StudentTests { get; set; } = new();
        public List<UpcomingClass> UpcomingClasses { get; set; } = new();

        public TeacherModel Teacher { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var roleUser = await _userManager.GetUserAsync(User);
            Teachers = await _db.Teachers.ToListAsync();
            foreach (var t in Teachers)
            {
                if (roleUser.Id == t.UserId)
                {
                    Teacher = t;
                }
            }
            return Page();


            // Example teacher info
            var teacher = _db.Teachers.FirstOrDefault();
            if (teacher != null)
            {
                TeacherName = $"{teacher.FirstName} {teacher.LastName}";
                Email = teacher.Email;
                ProfilePictureUrl = "https://images.pexels.com/photos/1181686/pexels-photo-1181686.jpeg";
                Rank = 14;
                ClassCount = _db.Timetables.Count(t => t.TeacherId == teacher.Id);
                StudentProgress = 73.0;
            }

            // Working hours demo
            WorkingHours = new List<WorkingHour>
            {
                new WorkingHour { Day = "Monday", StartTime = DateTime.Today.AddHours(8), EndTime = DateTime.Today.AddHours(16) },
                new WorkingHour { Day = "Tuesday", StartTime = DateTime.Today.AddHours(8), EndTime = DateTime.Today.AddHours(16) },
            };


            // Student tests demo
            StudentTests = new List<StudentTest>
            {
                new StudentTest { TestName = "Web Design Composition", Deadline = DateTime.Now.AddDays(1), StudentName = "Marie Stephens", StudentImageUrl = "", Status = "Active" },
                new StudentTest { TestName = "Math Midterm", Deadline = DateTime.Now.AddDays(3), StudentName = "Tommy Blake", StudentImageUrl = "", Status = "Pending" }
            };

        }

        // Supporting Classes
        public class WorkingHour
        {
            public string Day { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public class GroupChat
        {
            public string Icon { get; set; }          // Emoji or avatar
            public string GroupName { get; set; }     // Name of chat
            public string LastMessage { get; set; }
            public int UnreadCount { get; set; }
            public string TimeAgo { get; set; }       // e.g., "2h ago"
        }

        public class StudentTest
        {
            public string TestName { get; set; }
            public DateTime Deadline { get; set; }
            public string StudentName { get; set; }
            public string StudentImageUrl { get; set; }
            public string Status { get; set; }
        }

        public class UpcomingClass
        {
            public string Subject { get; set; }
            public string Time { get; set; }
            public string Room { get; set; }
            public DateTime Date { get; set; }
            public bool IsOnline { get; set; }
            public string OnlineDetails { get; set; }
        }
    }
}
