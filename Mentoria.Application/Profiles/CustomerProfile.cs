using AutoMapper;
using Mentoria.Application.Dtos;
using Mentoria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoria.Application.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerDto>()
                .ReverseMap();
        }
    }
}
