<<<<<<< HEAD
﻿namespace QuestApp.Models;
public class Location
=======
﻿namespace QuestApp.Models
>>>>>>> 8d47a51b3c82628feeba189941b80a5930c85712
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

