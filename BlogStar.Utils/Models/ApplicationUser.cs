using Microsoft.AspNetCore.Identity;

namespace BlogStar.Shared.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
    }
}
