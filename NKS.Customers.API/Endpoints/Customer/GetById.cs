using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Extensions;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class GetById : BaseAsyncEndpoint<string, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetById(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("/Customers/{id}")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(typeof(string), 204)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Returns customer for given id",
            Description = "Returns customer for given id",
            OperationId = "Customers.GetByid",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(string id)
        {
            if (id.HasValue())
                return BadRequest("Customer Id is required.");

            var customerId = Guid.Parse(id);

            var coreCustomer = await _customerRepository.GetByIdAsync(customerId);
            if (coreCustomer is null)
                return NotFound("Customer does not exist.");

            return Ok(CustomerResponse.FromDomainEntity(coreCustomer));
        }
    }
}
