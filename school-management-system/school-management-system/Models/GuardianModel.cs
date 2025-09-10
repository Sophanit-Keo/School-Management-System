namespace school_management_system.Models
{
    public class GuardianModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        // Reference Student and Guardian (many to many)
        public ICollection<StudentModel> Students { get; set; }
    }
}
