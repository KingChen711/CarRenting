using Microsoft.AspNetCore.Identity;

namespace CarRenting.Models.Entities;

public class Role : IdentityRole<int>
{
    public Guid RoleId { get; set; }
}