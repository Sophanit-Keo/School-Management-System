using school_management_system.Models.Users;

namespace school_management_system.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateOnly DOB { get; set; }
        public string Status { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;

        //Navigation Property Subjects, Timetables, Homeworks
        public ICollection<SubjectModel> Subjects { get; set; }
        public ICollection<TimetableModel> Timetables { get; set; }
        public ICollection<HomeworkModel> Homeworks { get; set; }
        public ICollection<TeacherUser> TeacherUsers { get; set; }
    }

}
