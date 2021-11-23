using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync()
        {
            var person = await _context.PersonPhone.AsNoTracking()
                .Include(c => c.PhoneNumberType)
                .Include(c => c.Person)
                .ToListAsync();

            return person;
        } 

        public async Task<PersonPhone> GetByIdAsync(string phone)
        {
            return await _context.PersonPhone.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
        }

        public async Task SaveAsync(PersonPhone personPhone)
        {
            _context.Add(personPhone);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PersonPhone personPhone)
        {
            try
            {
                var obj = await _context.PersonPhone.FirstOrDefaultAsync(x => x.PhoneNumber == personPhone.PhoneNumber);
                _context.PersonPhone.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
