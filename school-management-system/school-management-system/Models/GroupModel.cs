namespace school_management_system.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // FK Classroom 
        public int ClassroomId { get; set; }
        public ClassroomModel Classroom { get; set; }
        //FK Term
        public int TermId { get; set; }
        public TermModel Term { get; set; }
        // FK Timetable
        public int TimetableId { get; set; }
        public TimetableModel Timetable { get; set; }
        //FK Major
        public int MajorId { get; set; }
        public MajorModel Major { get; set; }
        // Navigation Property Enrollments, Homeworks, Attendances
        public ICollection<EnrollmentModel> Enrollments { get; set; }
        public ICollection<HomeworkModel> Homeworks { get; set; }
        public ICollection<AttendanceModel> Attendances { get; set; }
    }

}