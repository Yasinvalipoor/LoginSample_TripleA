using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginSampleTripleA.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string PassWord { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserName, PassWord, false, false);
                if (result.Succeeded)
                {
                    return Redirect(ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Invalid User Name Or Password");
            }
            return Page();

        }
    }
}
