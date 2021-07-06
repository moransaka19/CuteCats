using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace CuteCats.Models
{
    public class CatCreateViewModel
    {
        
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public string BIO { get; set; }
        
        public string Photo { get; set; }
    }
}
