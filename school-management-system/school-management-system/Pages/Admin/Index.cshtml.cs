using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace school_management_system.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
