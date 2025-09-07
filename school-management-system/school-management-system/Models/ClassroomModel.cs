namespace school_management_system.Models
{
    public class ClassroomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId;
        public ICollection<GroupModel> Groups { get; set; }
    }
}
