using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private IPersonPhoneService _personPhoneService;
        private IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {
            var result = await _personPhoneService.FindAllAsync();
            var response = new PersonPhoneListResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }

        public async Task<PersonPhone> GetByIdAsync(string phone)
        {
            var result = await _personPhoneService.GetByIdAsync(phone);
            return result;
        }

        public async Task SaveAsync(PersonPhone personPhone)
        {
            await _personPhoneService.SaveAsync(personPhone);
        }

        public async Task DeleteAsync(PersonPhone personPhone)
        {
            await _personPhoneService.DeleteAsync(personPhone);
        }
    }
}
