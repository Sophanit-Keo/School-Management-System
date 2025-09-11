namespace school_management_system.Models
{
    public class AssessmentModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // FK Subject and Reference (one to many)
        public int SubjectId;
        public SubjectModel Subject { get; set; }

        // FK Student and Reference (one to many)
        public int StudentId;
        public StudentModel Student { get; set; }

        // Reference Property (one to many)
        public ICollection<AssessmentModel> Assessment { get; set; }

    }
}
