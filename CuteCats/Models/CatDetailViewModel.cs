using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuteCats.Models
{
    public class CatDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BIO { get; set; }
        public string Photo { get; set; }
        public int Likes { get; set; }
    }
}
