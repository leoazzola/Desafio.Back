using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Response
{
    public class PhoneTypeResponse : BaseResponse
    {
        public List<PhoneTypeDto> PhoneTypeObjects { get; set; }
    }
}
