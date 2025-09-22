using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models.Users;

namespace school_management_system.Models
{
    public class AppDBContext(IConfiguration configuration) : IdentityDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("conn"));
        }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<GuardianModel> Guardians { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<TermModel> Terms { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<MajorModel> Majors { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<ClassroomModel> Classrooms { get; set; }
        public DbSet<TimetableModel> Timetables { get; set; }
        public DbSet<HomeworkModel> Homeworkss { get; set; }
        public DbSet<EnrollmentModel> Enrollments { get; set; }
        public DbSet<HomeworkSubmissionModel> HomeworkSubmissions { get; set; }
        public DbSet<ExamModel> Exams { get; set; }
        public DbSet<GradeModel> Grades { get; set; }
        public DbSet<AttendanceModel> Attendances { get; set; }
        public DbSet<StudentUser> StudentUsers { get; set; }
        public DbSet<TeacherUser> TeacherUsers { get; set; }

    }
}