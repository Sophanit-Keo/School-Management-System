namespace school_management_system.Models
{
    public class TeacherModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        // FK Auth and Reference
        public int AuthId;
        public AuthModel AuthModel { get; set; }

        // Reference Subject and  Teacher (many to many)
        public ICollection<SubjectModel> SubjectModels { get; set; }
    }
}
