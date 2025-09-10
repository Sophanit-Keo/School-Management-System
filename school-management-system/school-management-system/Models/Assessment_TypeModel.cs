namespace school_management_system.Models
{
    public class Assessment_TypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssessmentId;
        public ICollection<AssessmentModel> Assessments { get; set; }
    }
}
