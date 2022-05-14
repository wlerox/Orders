using AutoMapper;
using Order.Entity.DtoModel;
using Order.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DataAccess.Mapper
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<ProductDto, ProductEntity>().ReverseMap();

        }
    }
}
