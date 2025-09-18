namespace school_management_system.Models
{
    public class EnrollmentModel
    {
        public int Id { get; set; }
        public DateOnly EnrollmentDate { get; set; }

        // FK Student
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
        // FK Group 
        public int GroupId { get; set; }
        public GroupModel Group { get; set; }
    }

}
