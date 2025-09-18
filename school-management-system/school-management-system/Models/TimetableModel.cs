namespace school_management_system.Models
{
    public class TimetableModel
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        // Navigation Property Groups, Subjjects, Teachers, Classrooms
        public ICollection<GroupModel> Groups { get; set; }
        public ICollection<SubjectModel> Subjects { get; set; }
        public ICollection<TeacherModel> Teachers { get; set; }
        public ICollection<ClassroomModel> Classrooms { get; set; }
    }

}
