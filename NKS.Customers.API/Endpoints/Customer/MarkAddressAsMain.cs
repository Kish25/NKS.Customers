using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class MarkAddressAsMain : BaseAsyncEndpoint<AddressMoveRequest, CustomerResponse>
    {
        private readonly IAddressRepository _addressRepository;

        public MarkAddressAsMain(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpPut("/Customers/{id}/MarkAsPrimary")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [SwaggerOperation(
            Summary = "Creates a new customer",
            Description = "Creates a new customer",
            OperationId = "Customer.MarkAsPrimary",
            Tags = new[] { "Address" })
        ]
        public override async Task<ActionResult<CustomerResponse>> HandleAsync(AddressMoveRequest changeRequest)
        {
            await _addressRepository.MarkPrimaryToSecondaryAsync(changeRequest.CustomerId);
            await _addressRepository.MarkAsPrimaryAsync(changeRequest.AddressId);
            var response = new CustomerResponse
            {
                Id = changeRequest.CustomerId
            };
            return Ok(response);
        }
    }
}
