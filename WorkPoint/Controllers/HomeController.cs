using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkPoint.Models.ViewModels;
using WorkPoint.SL;
using WorkPoint.SL.DAL;

namespace WorkPoint.Controllers;

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
    public ViewResult Questions()
    {
        return View();
    }

    [HttpPost]
    public async Task<ViewResult> Recommendations()
    {
        var specialities = await specialityRepository.GetSpecialityListAsync();
        var userSkills = HttpContext.Request.Form
            .ToDictionary(kv => kv.Key, kv => kv.Value.ToString());

        var recommendations = SpecialtyRecommendationService.GetRecommendation(
            UserInfoParser.Parse(userSkills),
            specialities
            );

        foreach (var recommendation in recommendations)
        {
            recommendation.SkillsWithUserStatus = LocalizationService.GetLocalizedUkrainianDictionary(recommendation.SkillsWithUserStatus);
        }

        return View(recommendations);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
