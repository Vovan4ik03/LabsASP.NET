using Microsoft.AspNetCore.Mvc;
using TrainSchedule.Models;

namespace TrainSchedule.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ITrainRepository _repository;

        public NavigationMenuViewComponent(ITrainRepository repository)
        {
            _repository = repository;
        }


        public IViewComponentResult Invoke(string selectedType)
        {
            var types = _repository.Trains
                .Select(t => t.TrainType)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            ViewBag.SelectedType = selectedType;
            return View(types);
        }
    }
}
