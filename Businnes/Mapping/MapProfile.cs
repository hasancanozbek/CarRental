﻿
using AutoMapper;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Car, CarAddDto>().ReverseMap();
            CreateMap<Car, CarUpdateDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarFeatureDto>().ReverseMap();


            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
