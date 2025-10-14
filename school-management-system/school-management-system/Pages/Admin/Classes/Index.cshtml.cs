using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Classes
{
    public class IndexModel(AppDBContext _db) : PageModel
    {
        public IEnumerable<TimetableModel> Timetables { get; set; }

        [BindProperty]
        public GroupModel Group { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
        public SelectList ListGroups { get; set; }
        [BindProperty]
        public int SelectedGroup { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public async Task OnGet()
        {
            Groups = await _db.Groups.ToListAsync();
            ListGroups = new SelectList(Groups, nameof(GroupModel.Id), nameof(GroupModel.Name));

            Students = await _db.Students.ToListAsync();
            Teachers = await _db.Teachers.ToListAsync();
            Timetables = await _db.Timetables
               .Include(t => t.Group)
               .Include(t => t.Subject)
               .Include(t => t.Teacher)
               .Include(t => t.Classroom)
               .ToListAsync();
        }
    }
}
