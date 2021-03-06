using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> FindAllAsync();
        Task<PersonPhone> GetByIdAsync(string phone);
        Task SaveAsync(PersonPhone personPhone);
        Task DeleteAsync(PersonPhone personPhone);
    }
}
