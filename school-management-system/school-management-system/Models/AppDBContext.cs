using Microsoft.EntityFrameworkCore;

namespace school_management_system.Models
{
    public class AppDBContext(IConfiguration configuration) : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("conn"));
        }
        public DbSet<AuthModel> Authotications { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<GuardianModel> Guardians { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<GradeModel> Grades { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<MajorModel> Majors { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<ClassroomModel> Classrooms { get; set; }
        public DbSet<AssessmentModel> Assessments { get; set; }
        public DbSet<Assessment_TypeModel> Assessmen_Types { get; set; }
        public DbSet<RoleModel> Roles { get; set; }


    }
}
