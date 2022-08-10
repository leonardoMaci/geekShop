using Microsoft.AspNetCore.Identity;

namespace GeekShop.identityServer.Model.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
