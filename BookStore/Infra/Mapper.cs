using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using BookStore.Models;


namespace BookStore.Infra
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<BookEntity, Book>();
        }
    }

    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderEntity, Order>().
                ForMember(dest => dest.OrderDateTime , opt => opt.MapFrom(src => src.OrderDateTime.Date.ToUniversalTime()));
        }
    }
}
