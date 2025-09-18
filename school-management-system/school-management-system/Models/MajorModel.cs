namespace school_management_system.Models
{
    public class MajorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // FK Department
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }

        // Navigation Property
        public ICollection<GroupModel> Groups { get; set; }
    }

}