using Microsoft.AspNetCore.Identity;

namespace school_management_system.Models.Users
{
    public class UserEntity : IdentityUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "student";
    }
}
