using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkPoint.Models;
using WorkPoint.Models.ViewModels;
using WorkPoint.SL;
using WorkPoint.SL.DAL;

namespace WorkPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly WorkPointDbContext db;
        private readonly SpecialityRepository specialityRepository;

        public HomeController(WorkPointDbContext context)
        {
            db = context;
            specialityRepository = new SpecialityRepository(db);
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ViewResult> Recommendations()
        {
            var specialities = await specialityRepository.GetSpecialityListAsync();

            var recommendations = SpecialtyRecommendationService.GetRecommendation(new UserInfo(), specialities);

            return View(recommendations);
        }

        [HttpGet]
        public ViewResult About()
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
