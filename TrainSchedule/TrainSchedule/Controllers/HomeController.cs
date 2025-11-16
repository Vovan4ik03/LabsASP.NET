using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;
using System.Linq;
using TrainSchedule.Models;
using TrainSchedule.Models.ViewsModels;

namespace TrainSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrainScheduleDbContext _context;
        public int PageSize = 5;

        public HomeController(TrainScheduleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string type, int page = 1)
        {
            var filtered = _context.Trains
                .Include(t => t.Platform) 
                .AsEnumerable()
                .Where(t => string.IsNullOrEmpty(type)
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

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var train = _context.Trains
                .Include(t => t.Platform)
                .FirstOrDefault(t => t.Id == id);

            if (train == null)
                return NotFound();

            return View(train); 
        }

      
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Platforms = _context.Platforms.ToList(); 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Trains train)
        {
            if (ModelState.IsValid)
            {
                _context.Trains.Add(train);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Platforms = _context.Platforms.ToList();
            return View(train);
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var train = _context.Trains.Find(id);
            if (train == null) return NotFound();

            ViewBag.Platforms = _context.Platforms.ToList();
            return View(train);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Trains train)
        {
            if (ModelState.IsValid)
            {
                _context.Trains.Update(train);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Platforms = _context.Platforms.ToList();
            return View(train);
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var train = _context.Trains
                .Include(t => t.Platform)
                .FirstOrDefault(t => t.Id == id);

            if (train == null) return NotFound();
            return View(train); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var train = _context.Trains.Find(id);
            if (train != null)
            {
                _context.Trains.Remove(train);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}