using System;
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

        [HttpGet("/Customers/{Active:bool}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 204)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Returns list of customers",
            Description = "Returns list of customers",
            OperationId = "Customer.GetAll",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<List<CustomerResponse>>> HandleAsync(
            [FromQuery(Name = "Active")] bool isActive)
        {
            var response = new List<CustomerResponse>
            {
                new() { Id = Guid.NewGuid() },
                new() { Id = Guid.NewGuid() }
            };

            return Ok(response);
        }
    }
}