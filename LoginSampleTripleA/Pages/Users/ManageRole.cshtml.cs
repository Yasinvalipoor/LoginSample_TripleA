using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginSampleTripleA.Pages.Users
{
    public class ManageRoleModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityUser CurrentUser { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public List<string> UserRoles { get; set; }

        public ManageRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task OnGet(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserRoles = (await _userManager.GetRolesAsync(user)).ToList();
            AllRoles = _roleManager.Roles.ToList();
        }
    }
}
