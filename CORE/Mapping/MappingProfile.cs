using AutoMapper;
using CORE.DTOs.Product;
using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();
        }
    }
}
