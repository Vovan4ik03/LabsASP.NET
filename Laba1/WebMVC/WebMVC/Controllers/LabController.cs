using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class LabController : Controller
    {
        public IActionResult Index()
        {
            ViewData["LabNumber"] = "Лабораторна робота №1";
            ViewData["Topic"] = "Створення ASP.NET MVC застосунку";
            ViewData["Goal"] = "Навчитися працювати з контролерами та представленнями у MVC";
            ViewData["Name"] = "Володимир Макаров";
            return View();
        }
    }
}
