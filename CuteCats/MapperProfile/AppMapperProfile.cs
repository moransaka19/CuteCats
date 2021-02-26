using AutoMapper;
using CuteCats.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuteCats.MapperProfile
{
    public class AppMapperProfile : Profile 
    {
        public AppMapperProfile()
        {
            CreateMap<Cat, CatViewModel>()
                .ReverseMap();
            CreateMap<Cat, CatDetailViewModel>()
                .ReverseMap();
        }
    }
}
