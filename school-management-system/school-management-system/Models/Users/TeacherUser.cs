using Microsoft.AspNetCore.Identity;

namespace school_management_system.Models.Users
{
    public class TeacherUser : IdentityUser
    {
        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}
