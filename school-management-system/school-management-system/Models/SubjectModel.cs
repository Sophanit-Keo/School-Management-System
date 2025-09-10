namespace school_management_system.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // FK Major and Reference
        public int MajorID;
        public ICollection<MajorModel> Major { get; set; }

        // Reference Group and Subject (many to many)
        public ICollection<GroupModel> Groups { get; set; }

        // Reference Grade and Subject (many to many)
        public ICollection<GradeModel> Grades { get; set; }

        // Reference Teacher and Subject (many to many)
        public ICollection<TeacherModel> Teachers { get; set; }
    }
}
