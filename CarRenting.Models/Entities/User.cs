using Microsoft.AspNetCore.Identity;

namespace CarRenting.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public Guid UserId { get; set; }
    }
}
