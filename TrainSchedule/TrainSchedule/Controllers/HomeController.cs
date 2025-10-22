using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using TrainSchedule.Models;
using TrainSchedule.Models.ViewsModels;

namespace TrainSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrainRepository _repository;
        public int PageSize = 5;

        public HomeController(ITrainRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index(int page = 1)
        {
            var trains = _repository.Trains
             .OrderBy(t => t.Id)
             .Skip((page - 1) * PageSize)
             .Take(PageSize)
             .ToList();

            var model = new TrainListViewModel
            {
                Trains = trains,
                PaginInfo = new PaginInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Trains.Count()
                }
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
