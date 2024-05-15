using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginSampleTripleA.Pages.Account
{
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LogOutModel(SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
