using Microsoft.AspNetCore.Identity;

namespace LoginSampleTripleA.infra
{
    public class UserNamePasswordValidator : IPasswordValidator<IdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user, string? password)
        {
            if (password.Contains(user.UserName, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "UserNameInPassword",
                        Description = "You Can not Use Your Username in Your Password",

                    }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
