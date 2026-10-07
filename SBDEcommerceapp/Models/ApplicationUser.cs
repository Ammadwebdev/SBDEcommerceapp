using Microsoft.AspNetCore.Identity;

namespace SBDEcommerceapp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}