using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FoodTruckPlus.Dtos;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Order, OrderDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<OrderDto, Order>();
        }
    }
}