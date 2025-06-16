namespace QuestApp.Models;

public class GameSession
{
    public int Id { get; set; }

    public int AccessLinkId { get; set; }
    public AccessLink AccessLink { get; set; }

    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public int DurationSeconds { get; set; } = 1800;
    public bool IsActive { get; set; } = true;
    public DateTime? EndedAt { get; set; }
}

