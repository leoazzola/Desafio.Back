using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneListResponse> FindAllAsync();
        Task<PersonPhone> GetByIdAsync(string phone);
        Task SaveAsync(PersonPhone personPhone);
        Task DeleteAsync(PersonPhone personPhone);
    }
}
