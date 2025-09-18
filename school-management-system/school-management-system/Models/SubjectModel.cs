namespace school_management_system.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; }

        // Navigation Grades, Attendances,Homeworks ,Teachers, Timetables
        public ICollection<GradeModel> Grades { get; set; }
        public ICollection<AttendanceModel> Attendances { get; set; }
        public ICollection<HomeworkModel> Homeworks { get; set; }
        public ICollection<TeacherModel> Teachers { get; set; }
        public ICollection<TimetableModel> Timetables { get; set; }
    }

}