namespace school_management_system.Models
{
    public class MajorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Reference Property (one to many)
        public ICollection<DepartmentModel> Departments { get; set; }
        public ICollection<SubjectModel> Subjects { get; set; }
    }
}
