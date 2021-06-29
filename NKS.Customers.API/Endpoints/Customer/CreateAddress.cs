using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using Swashbuckle.AspNetCore.Annotations;
using Address = NKS.Customers.Core.Entities.Address;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class CreateAddress : BaseAsyncEndpoint<Address, CustomerResponse>
    {
        [HttpPost("/Customers/{Id:guid}/Address")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Creates a new customer address",
            Description = "Creates a new customer address",
            OperationId = "Address.Create",
            Tags = new[] { "Address" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(Address request)
        {
            var response = new CustomerResponse
            {
                Id = Guid.NewGuid()
            };
            return Ok(response);
        }
    }
}
