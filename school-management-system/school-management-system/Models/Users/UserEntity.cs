using Microsoft.AspNetCore.Identity;

namespace school_management_system.Models.Users
{
    public class UserEntity : IdentityUser
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
