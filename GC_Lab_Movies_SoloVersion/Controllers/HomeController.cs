using GC_Lab_Movies_SoloVersion.Models;
using GC_Lab_Movies_SoloVersion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GC_Lab_Movies_SoloVersion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieDAL movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<SingleMovieViewModel> movieListTest = new List<SingleMovieViewModel>();

            for (int i = 9622; i < 9632; i++)
            {
                SingleMovieViewModel singleMovie = new SingleMovieViewModel()
                {
                    MovieModel = movieDAL.GetMovieById(i),
                    BaseURL = movieDAL.GetBaseURL(),
                    ImageSizeParam = movieDAL.GetImageSizeParamXSmall() // not sure where the image size decision should be made.
                };

                movieListTest.Add(singleMovie);
            }



            return View(movieListTest);
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
