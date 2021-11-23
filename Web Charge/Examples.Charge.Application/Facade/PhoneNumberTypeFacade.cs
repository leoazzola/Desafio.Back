using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private IPhoneNumberTypeService _PhoneTypeService;
        private IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService PhoneTypeService, IMapper mapper)
        {
            _PhoneTypeService = PhoneTypeService;
            _mapper = mapper;
        }
        public async Task<PhoneTypeResponse> FindAllAsync()
        {
            var result = await _PhoneTypeService.FindAllAsync();
            var response = new PhoneTypeResponse();
            response.PhoneTypeObjects = new List<PhoneTypeDto>();
            response.PhoneTypeObjects.AddRange(result.Select(x => _mapper.Map<PhoneTypeDto>(x)));
            return response;
        }
    }
}
