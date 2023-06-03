using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyAsp.NETApp.Data;
using Microsoft.AspNetCore.Localization;
using MyAsp.NETApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace MyAsp.NETApp.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ItSparkTaskDbContext itsparkTaskDbContext;

        private readonly IStringLocalizer<HomeController> _localizer;



        public IActionResult Index(string returnUrl)
        {
            ViewData["WelcomeMessage"] = _localizer["WelcomeMessage"];
            var Student = itsparkTaskDbContext.Students.ToList();

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }



        public HomeController(ILogger<HomeController> logger, ItSparkTaskDbContext itSparkTaskDbContext, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
            this.itsparkTaskDbContext = itSparkTaskDbContext;
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

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
        }
    }
}