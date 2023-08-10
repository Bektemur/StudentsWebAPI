using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class Role : IdentityRole<string>
    {
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
    }
}
