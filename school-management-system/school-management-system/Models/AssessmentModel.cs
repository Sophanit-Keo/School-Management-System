namespace school_management_system.Models
{
    public class AssessmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SubjectId;
        public ICollection<SubjectModel> Subjects { get; set; }

    }
}
