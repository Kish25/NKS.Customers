using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class Delete : BaseAsyncEndpoint<Guid, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public Delete(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpDelete("/Customers/{Id:guid}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Marks customer as Inactive",
            Description = "Marks customer as Inactive",
            OperationId = "Customer.MakeInactive",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(Guid id)
        {
            // makes customer as anonymous by removing personal details and hashing email. 
            var response = new CustomerResponse
            {
                Id = Guid.NewGuid()
            };
            return Ok(response);
        }
    }
}
