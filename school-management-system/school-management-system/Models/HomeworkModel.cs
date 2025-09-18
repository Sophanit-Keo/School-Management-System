namespace school_management_system.Models
{
    public class HomeworkModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly AssignedDate { get; set; }
        public DateOnly DueDate { get; set; }

        // FK Group 
        public int GroupId { get; set; }
        public GroupModel Group { get; set; }
        // FK Subject
        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; }
        // FK Teacher
        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }
        // Navigattion Property
        public ICollection<HomeworkSubmissionModel> Submissions { get; set; }
    }

}
