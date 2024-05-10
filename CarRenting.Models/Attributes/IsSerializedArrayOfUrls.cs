using System.ComponentModel.DataAnnotations;

namespace CarRenting.Models.Attributes;

public class IsSerializedArrayOfUrlsAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult($"{validationContext.DisplayName} is required.");
        }

        if (!(value is string stringValue))
        {
            return new ValidationResult($"{validationContext.DisplayName} must be a string.");
        }

        var urls = stringValue.Split(','); // Assuming ',' is the delimiter for serialized URLs

        foreach (var url in urls)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out _))
            {
                return new ValidationResult($"{validationContext.DisplayName} contains an invalid URL.");
            }
        }

        return ValidationResult.Success;
    }
}