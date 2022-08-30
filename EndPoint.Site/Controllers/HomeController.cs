using Dara_Store.Application.Services.Common.Queries.GetSlider;
using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        public HomeController(ILogger<HomeController> logger, IGetSliderService getSliderService)
        {
            _logger = logger;
            _getSliderService = getSliderService;
        }

        public IActionResult Index()
        {
            HomePagesViewModel homePage = new HomePagesViewModel
            {
                Sliders = _getSliderService.Execute().Data,
            };

            return View(homePage);
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
