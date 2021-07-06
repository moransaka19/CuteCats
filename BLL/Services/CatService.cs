using BLL.Interfaces;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BLL.Services
{
    public class CatService : ICatService
    {
        private ICatRepository _catRepository;
        private BlobService _blobService;

        public CatService(ICatRepository catRepository,
            BlobService blobService)
        {
            _catRepository = catRepository;
            _blobService = blobService;
        }

        public Cat GetCatById(int id)
        {
            var cat = _catRepository.GetById(id);

            return cat;
        }

        public string GetCatPhoto(string fileName)
        {
            var picture = _blobService.DownloadPicture(fileName);
            var imgBase64 = Convert.ToBase64String(picture);

            return "data:image/gif;base64," + imgBase64;
        }

        public IQueryable<Cat> GetCats()
        {
            var cats = _catRepository.GetAll();

            return cats;
        }

        public void AddNewCat(Cat model)
        {
            _catRepository.Add(model);
        }

        public void UpdateCat(Cat model)
        {
            _catRepository.Update(model);
        }

        public void RemoveCat(Cat model)
        {
            _catRepository.Delete(model);
        }

        public void LikeCatById(int id)
        {
            var cat = GetCatById(id);
            cat.Likes++;
            _catRepository.Update(cat);
        }
    }
}
