namespace school_management_system.Models
{
    public class GradeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        //Reference Property (one to many)
        public ICollection<StudentModel> Students { get; set; }
        // Reference (many to many)
        public ICollection<SubjectModel> Subjects { get; set; }
    }
}
