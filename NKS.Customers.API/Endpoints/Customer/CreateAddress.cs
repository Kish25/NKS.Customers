using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class CreateAddress : BaseAsyncEndpoint<Address, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateAddress(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("Customers/{CustomerId:guid}/Addresses")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Creates a new customer address",
            Description = "Creates a new customer address",
            OperationId = "Address.Create",
            Tags = new[] { "Address" })
        ]
        public override async Task<ActionResult<CustomerResponse>>
            HandleAsync(Address request)
        {
            var response = new CustomerResponse
            {
                Id = Guid.NewGuid()
            };
            return Ok(response);
        }
    }
}
