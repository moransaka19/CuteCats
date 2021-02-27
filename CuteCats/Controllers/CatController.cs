using AutoMapper;
using BLL.Interfaces;
using CuteCats.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CuteCats.Controllers
{
    public class CatController : Controller
    {
        private ICatService _catService;
        private IMapper _mapper;

        public CatController(ICatService catService, IMapper mapper)
        {
            _catService = catService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var cats = _catService.GetCats();
            var catViewModels = _mapper.Map<IEnumerable<CatViewModel>>(cats);

            return View(catViewModels);
        }

        public IActionResult Details(int id)
        {
            var cat = _catService.GetCatById(id);
            var catDetailViewModel = _mapper.Map<CatDetailViewModel>(cat);
            catDetailViewModel.Photo = _catService.GetCatPhoto(catDetailViewModel.Photo);

            return View(catDetailViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatCreateViewModel model, IFormFile file)
        {
            var pathToFile = "CatImg/" + file.FileName;
            using (var fs = new FileStream(pathToFile, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            
            model.Photo = file;
            var cat = _mapper.Map<CatCreateViewModel, Cat>(model);
            _catService.AddNewCat(cat);

            return Redirect("Cat");
        }


        [HttpPost]
        public void UploadFile(IFormFile file)
        {
            int i = 9;
           
        }

        public IActionResult Like(int id)
        {
            _catService.LikeCatById(id);

            return Redirect("Cats");
        }
    }
}
