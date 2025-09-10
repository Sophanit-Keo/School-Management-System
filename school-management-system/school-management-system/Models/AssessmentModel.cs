namespace school_management_system.Models
{
    public class AssessmentModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // FK Subject and Reference
        public int SubjectId;
        public ICollection<SubjectModel> Subjects { get; set; }

        // FK Student and Reference
        public int StudentId;
        public ICollection<StudentModel> Students { get; set; }

    }
}
