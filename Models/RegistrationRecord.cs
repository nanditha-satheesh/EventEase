namespace EventEase.Models;

public class RegistrationRecord
{
    public required int Id { get; init; }
    public required int EventId { get; init; }
    public required string EventTitle { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public string Notes { get; init; } = string.Empty;
    public bool Attended { get; set; }
}
