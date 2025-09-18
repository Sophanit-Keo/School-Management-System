namespace school_management_system.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }
        public DateOnly AttendanceDate { get; set; }
        public int Status { get; set; }


        // FK Student
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
        // FK Group
        public int GroupId { get; set; }
        public GroupModel Group { get; set; }
        // FK Subject
        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; }
    }

}
