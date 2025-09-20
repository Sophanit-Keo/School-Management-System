namespace school_management_system.Models
{
    public class ClassroomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property Group
        public ICollection<TimetableModel> Timetables { get; set; }
    }

}