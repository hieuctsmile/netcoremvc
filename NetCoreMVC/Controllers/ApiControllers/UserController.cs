using Microsoft.AspNetCore.Mvc;
using NetCoreMVC.Models.Entities;
using NetCoreMVC.Services;

namespace NetCoreMVC.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserServices _userServices;

        public UserController(ILogger<HomeController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<JsonResult> Create()
        {
            var newUser = new User()
            {
                Email = "hieunc2@smartosc.com",
                Name = "Bazemin",
                Password = "hieu123",
                UniqueId = Guid.NewGuid().ToString()
            };
            await _userServices.CreateAsync(newUser);
            return await Task.FromResult(Json(newUser));
        }

        public async Task<JsonResult> Get()
        {
            var user = new User();
            return await Task.FromResult(Json(user));
        }

        public async Task<JsonResult> Update()
        {
            var newUser = new User();
            return await Task.FromResult(Json(true));
        }

        public async Task<JsonResult> Disable()
        {
            var newUser = new User();
            return await Task.FromResult(Json(true));
        }
    }
}
