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

        [BindProperty]
        public List<string> Roles { get; set; }

        [BindProperty]
        public string Id { get; set; }


        public ManageRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task OnGet(string id)
        {
            CurrentUser = await _userManager.FindByIdAsync(id);
            UserRoles = (await _userManager.GetRolesAsync(CurrentUser)).ToList();
            AllRoles = _roleManager.Roles.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CurrentUser = await _userManager.FindByIdAsync(Id);
            AllRoles = _roleManager.Roles.ToList();

            foreach (var item in AllRoles)
            {
                if (Roles.Contains(item.Name))
                {
                    if (!(await _userManager.IsInRoleAsync(CurrentUser, item.Name)))
                    {
                        await _userManager.AddToRoleAsync(CurrentUser, item.Name);
                    }
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(CurrentUser, item.Name))
                    {
                        await _userManager.RemoveFromRoleAsync(CurrentUser, item.Name);
                    }
                }
            }
            return RedirectToPage("List");
        }
    }
}
