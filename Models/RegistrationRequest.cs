using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class RegistrationRequest
{
    [Required(ErrorMessage = "Please select an event.")]
    public int? EventId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(60, ErrorMessage = "Name can be up to 60 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Notes can be up to 200 characters.")]
    public string Notes { get; set; } = string.Empty;
}
