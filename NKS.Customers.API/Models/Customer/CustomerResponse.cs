using System;
using System.Collections.Generic;
using DomainEntity = NKS.Customers.Core.Entities;

namespace NKS.Customers.API.Models.Customer
{
    public class CustomerResponse
    {
        public Guid                       Id           { get; set; }
        public string                     Title        { get; set; }
        public string                     Forename     { get; set; }
        public string                     Surname      { get; set; }
        public DateTime                   DateofBirth  { get; set; }
        public string                     MobileNumber { get; set; }
        public string                     EmailAddress { get; set; }
        public string                     Status       { get; set; }
        public List<DomainEntity.Address> Address      { get; set; }

        public static CustomerResponse FromDomainEntity(DomainEntity.Customer customer)
        {
            return new CustomerResponse
            {
                Id = customer.Id,
                Forename = customer.Forename,
                Surname = customer.Surname,
                DateofBirth = customer.DateOfBirth,
                EmailAddress = customer.Email,
                MobileNumber = customer.MobileNumber,
                Address = customer.Address
            };
        }

        public static List<CustomerResponse> FromDomainEntity(List<DomainEntity.Customer> customers)
        {
            var response = new List<CustomerResponse>();
            foreach (var customer in customers) response.Add(FromDomainEntity(customer));
            return response;
        }
    }
}
