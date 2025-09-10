namespace school_management_system.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Reference Group and Subject (many to many)
        public ICollection<SubjectModel> Subjects { get; set; }
    }
}
