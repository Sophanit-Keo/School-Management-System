namespace school_management_system.Models
{
    public class Assessmen_TypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssessmentId;
        public ICollection<AssessmentModel> Assessment { get; set; }
    }
}
