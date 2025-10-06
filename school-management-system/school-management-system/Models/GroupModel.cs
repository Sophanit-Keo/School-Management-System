namespace school_management_system.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // Navigation Property Enrollments, Homeworks, Attendances
        public ICollection<TimetableModel> Timetable { get; set; }
        public ICollection<EnrollmentModel> Enrollments { get; set; }
        public ICollection<HomeworkModel> Homeworks { get; set; }
        public ICollection<AttendanceModel> Attendances { get; set; }
    }

}