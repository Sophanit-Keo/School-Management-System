namespace school_management_system.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Reference Property
        public ICollection<AuthModel> Auths { get; set; }
    }
}
