namespace school_management_system.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MajorId;
        public ICollection<MajorModel> Major { get; set; }
    }
}
