using System.ComponentModel.DataAnnotations;

namespace CarRenting.Models.Dtos.User;

public record UserRegistrationDto
{
    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; init; } = null!;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; } = null!;

    public string? Email { get; init; }

    public string? PhoneNumber { get; init; }

    public ICollection<string> Roles { get; init; } = new List<string>();
}