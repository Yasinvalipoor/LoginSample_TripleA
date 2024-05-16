using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginSampleTripleA.Pages.Account
{
    [Authorize]
    public class LoginInfoModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
