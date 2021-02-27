using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICatService 
    {
        void LikeCatById(int id);
        IQueryable<Cat> GetCats();
        Cat GetCatById(int id);
        string GetCatPhoto(string fileName);
        void AddNewCat(Cat model);
    }
}
