using ASC.Solution.Services;
using ASC.Web.Configuration;
using ASC.Web.Models;
using ASC.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
//using ASC.Tests;

using ASC.Utilities;

namespace ASC.Web.Controllers
{
    public class HomeController : Controller
    {
        

        private IOptions<ApplicationSettings> _settings;

        private IOptions<ApplicationSettings> @object;

        public HomeController( IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
            this.@object = @object;
        }

        

        public IActionResult Index([FromServices] IEmailSender emailSender)
        {
            // Set Session 
            HttpContext.Session.SetSession("Test", _settings.Value);
            // Get Session 
            var settings = HttpContext.Session.GetSession<ApplicationSettings>("Test");
            // Usage of IOptions 
            ViewBag.Title = _settings.Value.ApplicationTitle;
            return View();
            //ViewBag.Title=_settings.Value.ApplicationTitle;
            //return View();
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
        public IActionResult DashBoard()
        {
            return View();
        }

        
    }
}
