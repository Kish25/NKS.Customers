using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class GetAllByStatus : BaseAsyncEndpoint<bool, List<CustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllByStatus(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("/Customers")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(typeof(string), 204)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Returns list of customers for given status",
            Description = "Returns either all or active customers .",
            OperationId = "Customer.GetAllByStatus",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<List<CustomerResponse>>> HandleAsync(
            [FromQuery(Name = "Active")] bool isActive)
        {
            IEnumerable<Core.Entities.Customer> customers = new List<Core.Entities.Customer>();


            customers = await _customerRepository.ListAllByStatusAsync(isActive);
            var result = CustomerResponse.FromDomainEntity(customers);

            return Ok(result);
        }
    }
}