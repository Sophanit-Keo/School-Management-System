namespace school_management_system.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // FK Major and Reference
        public int MajorId;
        public MajorModel Major { get; set; }
    }
}
