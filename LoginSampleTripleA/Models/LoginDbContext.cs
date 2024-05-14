using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoginSampleTripleA.Models
{
    public class LoginDbContext : IdentityDbContext<IdentityUser>
    {
        public LoginDbContext(DbContextOptions options) : base(options)
        {
        }
    }


}
