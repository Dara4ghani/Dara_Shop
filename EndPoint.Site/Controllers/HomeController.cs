using Dara_Store.Application.Interfaces.FacadPattern;
using Dara_Store.Application.Services.Common.Queries.GetHomePageImages;
using Dara_Store.Application.Services.Common.Queries.GetSlider;
using Dara_Store.Application.Services.Product.Queries.GetProductForSite;
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
        private readonly IGetHomePageImagesService _getHomePageImagesService;
        private readonly IProductFacad _productFacad;
        public HomeController(ILogger<HomeController> logger, IGetSliderService getSliderService, IGetHomePageImagesService getHomePageImagesService, IProductFacad productFacad)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _getHomePageImagesService = getHomePageImagesService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePagesViewModel homePage = new HomePagesViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _getHomePageImagesService.Execute().Data,
                Camera = _productFacad.GetProductForSiteService.Execute(Ordering.Newset
                , null, 1, 6, 25).Data.Products,
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
