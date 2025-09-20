namespace school_management_system.Models
{
    public class TimetableModel
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        // Navigation Property Groups, Subjjects, Teachers, Classrooms
        public int GroupId { get; set; }
        public GroupModel Group { get; set; }

        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; }
        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }
        public int ClassroomId { get; set; }
        public ClassroomModel Classroom { get; set; }
    }

}
