using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NKS.Customers.API.Extensions;
using NKS.Customers.API.Models.Customer;
using NKS.Customers.Core.Entities;
using NKS.Customers.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace NKS.Customers.API.Endpoints.Customer
{
    public class Create : BaseAsyncEndpoint<CustomerCreateRequest, string>
    {
        private readonly ICustomerRepository  _customerRepository;
        private readonly IAddressRepository   _addressRepository;

        public Create(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

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
        public override async Task<ActionResult<string>> HandleAsync(CustomerCreateRequest request)
        {
            var customer = new Core.Entities.Customer
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Forename = request.Forename,
                Initials = request.Initials,
                Surname = request.Surname,
                DateOfBirth = request.DateofBirth,
                Email = request.EmailAddress,
                HashedEmail = request.EmailAddress.GetHashValue(),
                MobileNumber = request.MobileNumber,
                Status = 1
            };
            var address = new Address
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                Address1 = request.Address1,
                Address2 = request.Address2,
                Address3 = request.Address3,
                County = request.County,
                Country = request.Country,
                Postcode = request.Postcode,
                IsCurrent = request.IsCurrent
            };

            await _customerRepository.CreateAsync(customer);
            await _addressRepository.CreateAsync(address);

            var url = HttpContext.Request.Host.Value + $"/Customers/{customer.Id}";


            return Ok(url);
        }
    }
}
