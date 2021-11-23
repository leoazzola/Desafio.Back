using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonPhoneProfile : Profile
    {
        public PersonPhoneProfile()
        {
            CreateMap<PersonPhone, PersonPhoneDto>()
                   .ReverseMap()
                   .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.BusinessEntityID))
                   .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                   .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
                   .ForPath(dest => dest.Person.Name, opt => opt.MapFrom(src => src.PersonName))
                   .ForPath(dest => dest.PhoneNumberType.Name, opt => opt.MapFrom(src => src.PhoneNumberTypeName));
        }
    }
}
