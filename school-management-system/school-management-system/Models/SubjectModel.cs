namespace school_management_system.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // FK Major and Reference
        public int MajorId;
        public MajorModel Major { get; set; }
        // Reference Property (one to many)
        public ICollection<AssessmentModel> Assessment { get; set; }

        // Reference Group and Subject (many to many)
        public ICollection<GroupModel> Groups { get; set; }

        // Reference Grade and Subject (many to many)
        public ICollection<GradeModel> Grades { get; set; }

        // Reference Teacher and Subject (many to many)
        public ICollection<TeacherModel> Teachers { get; set; }
    }
}
