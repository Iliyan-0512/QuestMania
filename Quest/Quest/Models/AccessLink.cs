namespace QuestApp.Models
{
    public class AccessLink
    {
        public int Id { get; set; }
        public string Code { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 10); 
        public int MaxUses { get; set; } = 5;
        public int UsedCount { get; set; } = 0;
        public DateTime? Expiration { get; set; }

        public List<Progress> Progress { get; set; } = new();
        public List<GameSession> GameSessions { get; set; } = new();
    }

}
