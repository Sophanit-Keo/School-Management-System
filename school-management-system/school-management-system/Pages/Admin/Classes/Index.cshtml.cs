using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school_management_system.Models;

namespace school_management_system.Pages.Admin.Classes
{
    public class IndexModel(AppDBContext _db) : PageModel
    {
        public IEnumerable<TimetableModel> Timetables { get; set; }
        public async Task OnGet()
        {
            Timetables = await _db.Timetables.ToListAsync();
        }
    }
}
