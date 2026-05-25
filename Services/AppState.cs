using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// Application state management service for sharing data across components
/// </summary>
public class AppState
{
    // Event to notify components when state changes
    public event Action? OnChange;

    // Current user session
    public string CurrentUserName { get; private set; } = "Guest";
    public bool IsLoggedIn { get; private set; } = false;

    // Selected event for registration
    public Event? SelectedEvent { get; private set; }

    // Sample events data
    private List<Event> _events = new()
    {
        new Event
        {
            Id = 1,
            Name = "Tech Conference 2024",
            Date = DateTime.Now.AddDays(30),
            Location = "Seattle Convention Center, WA",
            Description = "Join industry leaders for the latest in technology trends, AI, and cloud computing.",
            Category = "Technology",
            AvailableSeats = 500
        },
        new Event
        {
            Id = 2,
            Name = "Music Festival Summer Vibes",
            Date = DateTime.Now.AddDays(45),
            Location = "Central Park, New York, NY",
            Description = "Three days of amazing live music featuring top artists from around the world.",
            Category = "Entertainment",
            AvailableSeats = 2000
        },
        new Event
        {
            Id = 3,
            Name = "Career Development Workshop",
            Date = DateTime.Now.AddDays(15),
            Location = "Microsoft Campus, Redmond, WA",
            Description = "Learn essential career skills including resume building, interviewing, and networking.",
            Category = "Education",
            AvailableSeats = 100
        },
        new Event
        {
            Id = 4,
            Name = "Food & Wine Expo",
            Date = DateTime.Now.AddDays(60),
            Location = "San Francisco Marriott, CA",
            Description = "Experience culinary delights from world-renowned chefs and premium wine tastings.",
            Category = "Food & Drink",
            AvailableSeats = 300
        },
        new Event
        {
            Id = 5,
            Name = "Startup Pitch Competition",
            Date = DateTime.Now.AddDays(20),
            Location = "Boston Innovation Center, MA",
            Description = "Watch entrepreneurs pitch their innovative ideas to venture capitalists and win funding.",
            Category = "Business",
            AvailableSeats = 150
        },
        new Event
        {
            Id = 6,
            Name = "Yoga & Wellness Retreat",
            Date = DateTime.Now.AddDays(90),
            Location = "Sedona Retreat Center, AZ",
            Description = "A weekend of mindfulness, yoga, meditation, and holistic wellness practices.",
            Category = "Health & Wellness",
            AvailableSeats = 50
        }
    };

    // Registrations storage
    private List<Registration> _registrations = new();

    // Get all events
    public List<Event> GetAllEvents() => _events;

    // Get event by ID
    public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);

    // Get filtered events
    public List<Event> GetFilteredEvents(string searchTerm, string category)
    {
        var filtered = _events.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            filtered = filtered.Where(e =>
                e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(category) && category != "All")
        {
            filtered = filtered.Where(e => e.Category == category);
        }

        return filtered.ToList();
    }

    // Get all categories
    public List<string> GetCategories()
    {
        return _events.Select(e => e.Category).Distinct().OrderBy(c => c).ToList();
    }

    // Set selected event
    public void SetSelectedEvent(Event? eventItem)
    {
        SelectedEvent = eventItem;
        NotifyStateChanged();
    }

    // Login functionality (simplified for demo)
    public void Login(string userName)
    {
        CurrentUserName = userName;
        IsLoggedIn = true;
        NotifyStateChanged();
    }

    // Logout functionality
    public void Logout()
    {
        CurrentUserName = "Guest";
        IsLoggedIn = false;
        NotifyStateChanged();
    }

    // Add registration
    public void AddRegistration(Registration registration)
    {
        registration.Id = _registrations.Count + 1;
        _registrations.Add(registration);
        NotifyStateChanged();
    }

    // Get all registrations
    public List<Registration> GetAllRegistrations() => _registrations;

    // Get registration by ID
    public Registration? GetRegistrationById(int id) => _registrations.FirstOrDefault(r => r.Id == id);

    // Toggle attendance
    public void ToggleAttendance(int registrationId)
    {
        var registration = _registrations.FirstOrDefault(r => r.Id == registrationId);
        if (registration != null)
        {
            registration.IsAttending = !registration.IsAttending;
            NotifyStateChanged();
        }
    }

    // Get attendance statistics
    public (int Total, int Present, int Absent) GetAttendanceStats()
    {
        var total = _registrations.Count;
        var present = _registrations.Count(r => r.IsAttending);
        var absent = total - present;
        return (total, present, absent);
    }

    // Notify state changed
    private void NotifyStateChanged() => OnChange?.Invoke();
}
