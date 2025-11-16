namespace TrainSchedule.Models
{
    public interface ITrainRepository
    {
        IQueryable<Trains> Trains { get; }

    }
}
