using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Extensions;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class MarkAsActive : BaseAsyncEndpoint<string, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public MarkAsActive(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPut("/Customers/{id}/Activate")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Marks customer as Inactive",
            Description = "Marks customer as Inactive",
            OperationId = "Customer.MakeActive",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(string id)
        {
            if (id.HasValue())
                return BadRequest("Customer Id is required.");

            var customerId = Guid.Parse(id);

            await _customerRepository.MarkAsActiveAsync(customerId);
            var response = new CustomerResponse
            {
                Id = customerId
            };

            return Ok(response);
        }
    }
}
