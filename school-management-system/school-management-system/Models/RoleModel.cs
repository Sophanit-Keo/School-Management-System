namespace school_management_system.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relationship
        //FK
        public int AuthsID;
        public ICollection<AuthModel> Auths { get; set; }
    }
}
