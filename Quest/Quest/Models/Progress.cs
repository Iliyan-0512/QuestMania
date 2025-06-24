<<<<<<< HEAD
﻿namespace QuestApp.Models;

public class Progress
=======
﻿namespace QuestApp.Models
>>>>>>> 8d47a51b3c82628feeba189941b80a5930c85712
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
