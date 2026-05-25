using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

/// <summary>
/// Represents a user registration for an event
/// </summary>
public class Registration
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    [RegularExpression(@"^[\d\s\-\+\(\)]+$", ErrorMessage = "Phone number can only contain digits, spaces, and +-() characters")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select an event")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid event")]
    public int SelectedEventId { get; set; }

    public string? SelectedEventName { get; set; }

    [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions")]
    public bool AcceptTerms { get; set; }

    public bool IsAttending { get; set; } = false;

    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}
