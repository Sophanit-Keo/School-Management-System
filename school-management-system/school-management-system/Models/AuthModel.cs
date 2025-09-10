namespace school_management_system.Models
{
    public class AuthModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // FK Role and Reference
        public int RoleId { get; set; }
        public ICollection<RoleModel> Roles { get; set; }
    }
}
