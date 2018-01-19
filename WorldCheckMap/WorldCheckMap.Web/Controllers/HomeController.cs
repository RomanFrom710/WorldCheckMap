using Microsoft.AspNetCore.Mvc;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoreDataService _initializationService;

        public HomeController(ICoreDataService initializationService)
        {
            _initializationService = initializationService;
        }

        public IActionResult Index()
        {
            var initData = _initializationService.GetClientInitData();
            return View(initData);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
