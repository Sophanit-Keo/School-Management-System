namespace school_management_system.Models
{
    public class AuthModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // FK Role and Reference
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }

        // Reference Property (one to many)
        public ICollection<StudentModel> Students { get; set; }
        public ICollection<TeacherModel> Teachers { get; set; }
    }
}
