namespace school_management_system.Models
{
    public class StudentModel

    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        // FK Auth and Reference

        public int AuthID;
        public ICollection<AuthModel> Auths { get; set; }

        // FK Grade and Reference
        public int GradeId;
        public ICollection<GradeModel> Grades { get; set; }

        // Reference Student and Guardian (many to many)
        public ICollection<GuardianModel> Guardians { get; set; }
    }
}
