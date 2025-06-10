using System.Collections;
using Microsoft.EntityFrameworkCore;
using Quest.Models;

namespace Quest.Data
{
    public class QuestDbContext:DbContext
    {
        public QuestDbContext(DbContextOptions<QuestDbContext> options) 
            : base(options) { }

        public DbSet<AccessLink> AccessLinks { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Queue> Quests { get; set; }
    }
}
