using AutoMapper;
using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.AutoMapper.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<CategoryAddDto, Category>().ReverseMap();

            CreateMap<OrderAddDto, Order>().ReverseMap();

            CreateMap<OrderLineAddDto, OrderLine>().ReverseMap();

            CreateMap<UserAddDto, User>().ReverseMap();

            CreateMap<ProductAddDto, Product>().ReverseMap();
        }

    }
}
