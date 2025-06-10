using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Quest.Data;

namespace Quest
{
    public class QuestDbContextFactory   :IDesignTimeDbContextFactory<QuestDbContext>
    {
        public QuestDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<QuestDbContext>();
            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));

            return new QuestDbContext(optionsBuilder.Options);
        }
    }
}
