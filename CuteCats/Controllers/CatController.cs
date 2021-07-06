using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
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
        private readonly BlobService _blobService;
        private IMapper _mapper;

        public CatController(ICatService catService,
            BlobService blobService,
            IMapper mapper)
        {
            _catService = catService;
            _blobService = blobService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var cats = _catService.GetCats();
            var catViewModels = _mapper.Map<IEnumerable<CatViewModel>>(cats).OrderByDescending(c => c.Likes);

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
        public IActionResult Create(CatCreateViewModel model, IFormFile file)
        {
            _blobService.UploadPicture(file.FileName, file.OpenReadStream());
            model.Photo = file.FileName;
            var cat = _mapper.Map<CatCreateViewModel, Cat>(model);
            _catService.AddNewCat(cat);

            return Redirect("../Cat");
        }

        public IActionResult Edit(int id)
        {
            var cat = _catService.GetCatById(id);
            var catEditViewModel = _mapper.Map<CatEditViewModel>(cat);
            catEditViewModel.Photo = _catService.GetCatPhoto(catEditViewModel.Photo);

            return View(catEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CatEditViewModel model, IFormFile file)
        {
            if (file != null)
            {
                _blobService.UploadPicture(file.FileName, file.OpenReadStream());
                model.Photo = file.FileName;
                var cat = _mapper.Map<Cat>(model);
                _catService.UpdateCat(cat);
            }

            return Redirect("../Index");
        }

        public IActionResult Delete(int id)
        {
            var cat = _catService.GetCatById(id);
            var catDetailViewModel = _mapper.Map<CatDetailViewModel>(cat);

            return View(catDetailViewModel);
        }

        [HttpPost]
        public IActionResult Delete(CatDetailViewModel model)
        {
            var cat = _catService.GetCatById(model.Id);
            _blobService.DeletePicture(cat.Photo);
            _catService.RemoveCat(cat);
            return Redirect("../");
        }

        public IActionResult Like(int id)
        {
            _catService.LikeCatById(id);

            return Redirect("../Index");
        }
    }
}
