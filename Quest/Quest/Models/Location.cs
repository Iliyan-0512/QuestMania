﻿namespace QuestApp.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AreaHint { get; set; }

        public List<Quest> Quests { get; set; } = new();
    }
}

