namespace school_management_system.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SubjectModel> Subjects { get; set; }
    }
}
