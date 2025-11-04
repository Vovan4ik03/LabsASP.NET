using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;
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

        public IActionResult Index(string type, int page = 1)
        {
            
            var filtered = _repository.Trains
                .AsEnumerable()
    .            Where(t => string.IsNullOrEmpty(type)
                    || t.TrainType.ToLower() == type.ToLower())
                 .OrderBy(t => t.Id);

            var totalItems = filtered.Count();

            var model = new TrainsListViewModel
            {
                Trains = filtered
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList(),

                PaginInfo = new PaginInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = totalItems
                },

                CurrentType = type 
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
