using Fitness_All_in_One.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
//using NETCore.MailKit.Core;
using System.Diagnostics;
//using Fitness_All_in_One.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Fitness_All_in_One.Areas.Identity.Pages.Account;

namespace Fitness_All_in_One.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly IEmailServices _emailServices;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger ,/* IEmailServices emailServices*/ UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
       //     _emailServices = emailServices;
            _userManager = userManager;
        } 

        public async Task <IActionResult> Index()
        {
            /*UserEmailOptions options = new UserEmailOptions

            {
                ToEmails = new List<string>() { "test@gmail.com" },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                      new KeyValuePair<string, string>("{{UserName}}", "John")
                }
            };

            await _emailServices.SendTestEmail(options);*/
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