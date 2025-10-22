using Microsoft.EntityFrameworkCore;

namespace TrainSchedule.Models
{
    public class TrainScheduleDbContext: DbContext
    {
            public TrainScheduleDbContext(DbContextOptions<TrainScheduleDbContext> options) : base(options) { }
            public DbSet<Trains> Trains => Set<Trains>();
    }
}
