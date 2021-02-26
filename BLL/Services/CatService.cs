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

        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public Cat GetCatById(int id)
        {
            var cat = _catRepository.GetById(id);

            if (cat == null)
            {
                throw new NullReferenceException();
            }

            return cat;
        }

        public string GetCatPhoto(string fileName)
        {
            var path = "CatImg/" + fileName;
            var imageArray = System.IO.File.ReadAllBytes(path);
            var imgBase64 = Convert.ToBase64String(imageArray);

            return "data:image/gif;base64," + imgBase64;
        }

        public IQueryable<Cat> GetCats()
        {
            var cats = _catRepository.GetAll();

            return cats;
        }

        public void LikeCatById(int id)
        {
            var cat = GetCatById(id);
            cat.Likes++;
            _catRepository.Update(cat);
        }
    }
}
