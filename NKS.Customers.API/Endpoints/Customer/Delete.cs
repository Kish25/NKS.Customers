using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Extensions;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class Delete : BaseAsyncEndpoint<string, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository  _addressRepository;

        public Delete(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        [HttpPatch("/Customers/delete/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Marks customer as Inactive",
            Description = "Marks customer as Inactive",
            OperationId = "Customer.MakeInactive",
            Tags = new[] { "Customers" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(string id)
        {
            if (id.HasValue())
                return BadRequest("Customer Id is required.");

            var customerId = Guid.Parse(id);

            // Removed as better not to delete an customer rather set to anonymous object....
            //await _addressRepository.DeleteAllForCustomerAsync(customerId);
            //await _customerRepository.DeleteAsync(customerId);

            await _customerRepository.MarkAsDeletedAsync(customerId);

            return Ok();
        }
    }
}
