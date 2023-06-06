using Microsoft.AspNetCore.Identity;

namespace OnlineShoppingStore.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
