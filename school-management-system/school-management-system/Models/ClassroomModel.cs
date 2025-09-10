namespace school_management_system.Models
{
    public class ClassroomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // FK Group and Reference
        public int GroupId;
        public ICollection<GroupModel> Groups { get; set; }
    }
}
