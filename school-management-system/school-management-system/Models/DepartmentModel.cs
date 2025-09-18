namespace school_management_system.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<MajorModel> Majors { get; set; }
    }
}