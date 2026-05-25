namespace EventEase.Models;

public class EventInfo
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Date { get; init; }
    public required string Venue { get; init; }
    public required string Description { get; init; }
    public int Capacity { get; init; }
    public int RegisteredCount { get; set; }
}
