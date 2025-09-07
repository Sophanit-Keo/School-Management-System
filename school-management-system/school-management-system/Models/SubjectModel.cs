namespace school_management_system.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MajorID;
        public ICollection<MajorModel> Major { get; set; }
        public ICollection<GroupModel> Group { get; set; }
        public ICollection<GradeModel> Grade { get; set; }

        //Relatioonship
        public ICollection<TeacherModel> Teacher { get; set; }
    }
}
