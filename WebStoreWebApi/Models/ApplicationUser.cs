using Microsoft.AspNetCore.Identity;

namespace WebStoreWebApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }

        public string LName { get; set; }
    }
}
