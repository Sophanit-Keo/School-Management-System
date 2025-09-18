namespace school_management_system.Models
{
    public class ExamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly ExamDate { get; set; }
        public int MaxMark { get; set; }

        // Navigation Property Grades
        public ICollection<GradeModel> Grades { get; set; }
    }

}
