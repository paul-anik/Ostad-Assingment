using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize] // Requires authentication
public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        // Redirect to Login if not authenticated
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/Account/Login");
        }
        return Page();
    }
}
