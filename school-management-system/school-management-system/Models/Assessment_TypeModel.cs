namespace school_management_system.Models
{
    public class Assessment_TypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // FK and Reference Property Assessment Type and Assessemnt (one to many)
        public int AssessmentId;
        public AssessmentModel Assessment { get; set; }
    }
}
