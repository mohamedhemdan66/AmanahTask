﻿using AmanahTask.Api.DTOs;
using AmanahTask.Core.Domain;
using AutoMapper;

namespace AmanahTask
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogDto,Blog>().ReverseMap();

        }
    }

}
