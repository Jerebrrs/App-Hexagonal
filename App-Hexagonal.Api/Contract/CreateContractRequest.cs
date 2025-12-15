using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Hexagonal.Api.Contract
{
    public class CreateContractRequest
    {
        public Guid UserId { get; set; }
        public Guid PropertyId { get; set; }
    }
}