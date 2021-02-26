using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cat : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Likes { get; set; }
        public string BIO { get; set; }
        public string Photo { get; set; }
    }
}
