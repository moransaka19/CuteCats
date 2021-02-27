using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CatRepository : BaseRepository<Cat>, ICatRepository
    {
        public CatRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
