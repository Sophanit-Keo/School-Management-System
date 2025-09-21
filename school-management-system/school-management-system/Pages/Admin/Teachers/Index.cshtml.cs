using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Teachers
{
    public class IndexModel(AppDBContext _db) : PageModel
    {
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public async Task OnGet()
        {
            Teachers = await _db.Teachers
                .Include(t => t.Subjects)
                .ToListAsync();
        }
    }
}
