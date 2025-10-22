namespace TrainSchedule.Models
{
    public class Trains
    {
        public int Id { get; set; }
        public required string TrainName { get; set; }
        public required string TrainType { get; set; }
        public required string TrainNumber { get; set; }

    }
}
