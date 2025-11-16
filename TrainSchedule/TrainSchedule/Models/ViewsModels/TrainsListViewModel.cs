using System.Diagnostics;

namespace TrainSchedule.Models.ViewsModels
{
    public class TrainsListViewModel
    {
        public IEnumerable<Trains> Trains { get; set; } = new List<Trains>();
        public PaginInfo PaginInfo { get; set; } = new PaginInfo();
        public string? CurrentType { get; set; }
    }
}
