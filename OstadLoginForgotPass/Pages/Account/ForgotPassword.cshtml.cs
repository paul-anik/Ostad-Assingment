using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ForgotPasswordModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public ForgotPasswordModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Input.NewPassword != Input.ConfirmPassword)
        {
            ModelState.AddModelError(string.Empty, "Passwords do not match.");
            return Page();
        }

        var user = await _userManager.FindByNameAsync(Input.UserName);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "User not found.");
            return Page();
        }

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetResult = await _userManager.ResetPasswordAsync(user, resetToken, Input.NewPassword);

        if (resetResult.Succeeded)
        {
            return RedirectToPage("/Account/Login");
        }

        foreach (var error in resetResult.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return Page();
    }
}
