using Microsoft.AspNetCore.Identity;

namespace school_management_system.Models.Users
{
    public class StudentUser : IdentityUser
    {
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
    }
}
