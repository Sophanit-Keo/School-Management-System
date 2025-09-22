using school_management_system.Models.Users;

namespace school_management_system.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string SpecialRequirements { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;


        // Navigation Property Attendances, Grades, HomeworkSubmissions, Enrollments, Guardians
        public ICollection<AttendanceModel> Attendances { get; set; }
        public ICollection<GradeModel> Grades { get; set; }
        public ICollection<HomeworkSubmissionModel> HomeworkSubmissions { get; set; }
        public ICollection<EnrollmentModel> Enrollments { get; set; }
        public ICollection<GuardianModel> Guardians { get; set; }
        public ICollection<StudentUser> StudentUsers { get; set; }
    }

}