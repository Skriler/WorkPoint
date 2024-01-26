using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkPoint.DAL;
using WorkPoint.Models;

namespace WorkPoint.Controllers
{
    public class HomeController : Controller
    {
        private WorkPointDB db;

        public HomeController(WorkPointDB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
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
