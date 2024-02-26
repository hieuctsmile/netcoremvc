using Microsoft.AspNetCore.Mvc;
using NetCoreMVC.Models;
using NetCoreMVC.Models.Entities;
using NetCoreMVC.Services;
using System.Diagnostics;

namespace NetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserServices _userServices;

        public HomeController(ILogger<HomeController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("BazeminLoasasdg", this.GetType().Name);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            var newUser = new User()
            {
                Email = "hieunc2@smartosc.com",
                Name = "Bazemin",
                Password = "hieu123",
                UniqueId = Guid.NewGuid().ToString()
            };

            if (await _userServices.GetAsync(newUser.UniqueId) == null) await _userServices.CreateAsync(newUser);

            var users = await _userServices.GetAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
