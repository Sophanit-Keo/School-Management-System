namespace school_management_system.Models
{
    public class TermModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Proterty Groups
        public ICollection<GroupModel> Groups { get; set; }
    }

}
