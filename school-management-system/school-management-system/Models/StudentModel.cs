namespace school_management_system.Models
{
    public class StudentModel

    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        public int AuthID;
        public ICollection<AuthModel> Auths { get; set; }

        public ICollection<GuardianModel> Guardians { get; set; }
        public int GradeID;
        public ICollection<GradeModel> Grades { get; set; }
    }
}
