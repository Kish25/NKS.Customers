using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class MarkAsInactive : BaseAsyncEndpoint<Guid, CustomerResponse>
    {
        [HttpPut("/Customers/{Id:guid}/Deactivate")]
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
            var response = new CustomerResponse
            {
                Id = Guid.NewGuid()
            };


            return Ok(response);
        }
    }
}
