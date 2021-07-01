using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class GetById : BaseAsyncEndpoint<Guid, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetById(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("/Customers/{Id:guid}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 204)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Returns customer for given id",
            Description = "Returns customer for given id",
            OperationId = "Customers.GetByid",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(Guid id)
        {
            // var coreCustomer = _customerRepository.GetByIdAsync(request.Id);

            return Ok();
        }
    }
}
