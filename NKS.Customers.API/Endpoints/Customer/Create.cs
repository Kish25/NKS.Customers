using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class Create : BaseAsyncEndpoint<CustomerCreateRequest, CustomerResponse>
    {
        [HttpPost("/Customers")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Creates a new customer",
            Description = "Creates a new customer",
            OperationId = "Customer.Create",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(CustomerCreateRequest request)
        {
            var response = new CustomerResponse
            {
                Id = Guid.NewGuid()
            };
            return Ok(response);
        }
    }
}
