using AutoMapper;
using BLL.Interfaces;
using CuteCats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CuteCats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICatService _catService;
        private IMapper _mapper;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cats()
        {
            var cats = _catService.GetCats();
            var catViewModels = _mapper.Map<IEnumerable<CatViewModel>>(cats);
          
            return View(catViewModels);
        }

        public IActionResult CatDetail(int id)
        {
            var cat = _catService.GetCatById(id);
            var catDetailViewModel = _mapper.Map<CatDetailViewModel>(cat);

            return View(catDetailViewModel);
        }

        public IActionResult Like(int id)
        {
            _catService.LikeCatById(id);

            return Redirect("Cats");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
