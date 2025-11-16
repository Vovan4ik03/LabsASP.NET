using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainSchedule.Models;

namespace TrainSchedule.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly TrainScheduleDbContext _context;

        public PlatformsController(TrainScheduleDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var platforms = _context.Platforms
                .OrderBy(p => p.PlatformNumber)
                .ToList();
            return View(platforms);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var platform = _context.Platforms
                .FirstOrDefault(p => p.Id == id);

            if (platform == null) return NotFound();

            return View(platform);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Platform platform)
        {
            if (ModelState.IsValid)
            {
                _context.Platforms.Add(platform);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(platform);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var platform = _context.Platforms.Find(id);
            if (platform == null) return NotFound();
            return View(platform);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Platform platform)
        {
            if (ModelState.IsValid)
            {
                _context.Platforms.Update(platform);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(platform);
        }

       
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var platform = _context.Platforms.Find(id);
            if (platform == null) return NotFound();
            return View(platform);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var platform = _context.Platforms.Find(id);
            if (platform != null)
            {
                _context.Platforms.Remove(platform);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
