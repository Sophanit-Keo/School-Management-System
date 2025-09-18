namespace school_management_system.Models
{
    public class HomeworkSubmissionModel
    {
        public int Id { get; set; }
        public DateOnly SubmissionDate { get; set; }
        public string Content { get; set; }
        public decimal Mark { get; set; }

        // FK Homework
        public int HomeworkId { get; set; }
        public HomeworkModel Homework { get; set; }
        //FK Student
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
    }


}
