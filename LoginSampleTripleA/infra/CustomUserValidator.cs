using Microsoft.AspNetCore.Identity;

public class CustomUserValidator : IUserValidator<IdentityUser>
{
    private readonly string companyEmail = "@amuyasincompany.com";
    public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user)
    {
        if (!user.Email.EndsWith(companyEmail, StringComparison.OrdinalIgnoreCase))
        {
            return Task.FromResult(IdentityResult.Failed(
                new IdentityError
                {
                    Code = "InvalidEmail",
                    Description = "You Should Use Company Email",

                }));
        }
        return Task.FromResult(IdentityResult.Success);
    }
}
