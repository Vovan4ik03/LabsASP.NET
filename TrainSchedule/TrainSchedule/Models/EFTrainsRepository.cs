using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSchedule.Models
{
    public class EFTrainsRepository : ITrainRepository
    {
        private TrainScheduleDbContext context;
        public EFTrainsRepository(TrainScheduleDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Trains> Trains => context.Trains;

    }
}
