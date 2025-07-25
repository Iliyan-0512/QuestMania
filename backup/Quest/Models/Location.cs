namespace QuestApp.Models
{
    public class Location
    {
        public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AreaHint { get; set; } = string.Empty;

        public List<Quest> Quests { get; set; } = new();
    }
}

