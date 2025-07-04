namespace QuestApp.Models
{
    public class Progress
    {
        public int Id { get; set; }

        public int QuestId { get; set; }
        public Quest Quest { get; set; }

        public int AccessLinkId { get; set; }
        public AccessLink AccessLink { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
        public int SkippedTimes { get; set; } = 0;
    }
}
