using EventEase.Models;

namespace EventEase.Services;

public class EventStateService
{
    private readonly List<EventInfo> _events =
    [
        new()
        {
            Id = 1,
            Title = "Community Networking Night",
            Date = "June 12, 2026",
            Venue = "Downtown Hub",
            Description = "Meet professionals, founders, and mentors in a relaxed evening session.",
            Capacity = 50
        },
        new()
        {
            Id = 2,
            Title = "Intro to Blazor Workshop",
            Date = "June 20, 2026",
            Venue = "Tech Campus Room A",
            Description = "Hands-on workshop for building interactive web apps with Blazor.",
            Capacity = 35
        },
        new()
        {
            Id = 3,
            Title = "Startup Pitch Day",
            Date = "July 1, 2026",
            Venue = "Innovation Hall",
            Description = "Early-stage teams pitch ideas and receive live feedback from judges.",
            Capacity = 80
        }
    ];

    private readonly List<RegistrationRecord> _registrations = [];
    private int _registrationSeed;

    public IReadOnlyList<EventInfo> Events => _events;
    public IReadOnlyList<RegistrationRecord> Registrations => _registrations;

    public bool Register(RegistrationRequest request, out string message)
    {
        if (request.EventId is null)
        {
            message = "Please choose an event before registering.";
            return false;
        }

        var selectedEvent = _events.FirstOrDefault(x => x.Id == request.EventId.Value);
        if (selectedEvent is null)
        {
            message = "The selected event does not exist.";
            return false;
        }

        if (selectedEvent.RegisteredCount >= selectedEvent.Capacity)
        {
            message = "Registration is closed because this event is full.";
            return false;
        }

        _registrationSeed++;
        _registrations.Add(new RegistrationRecord
        {
            Id = _registrationSeed,
            EventId = selectedEvent.Id,
            EventTitle = selectedEvent.Title,
            Name = request.Name.Trim(),
            Email = request.Email.Trim(),
            Notes = request.Notes.Trim(),
            Attended = false
        });

        selectedEvent.RegisteredCount++;
        message = $"You are registered for {selectedEvent.Title}.";
        return true;
    }

    public void UpdateAttendance(int registrationId, bool attended)
    {
        var record = _registrations.FirstOrDefault(x => x.Id == registrationId);
        if (record is not null)
        {
            record.Attended = attended;
        }
    }
}
