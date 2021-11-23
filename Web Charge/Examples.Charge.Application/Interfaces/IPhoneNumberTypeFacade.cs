using Examples.Charge.Application.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPhoneNumberTypeFacade
    {
        Task<PhoneTypeResponse> FindAllAsync();
    }
}
