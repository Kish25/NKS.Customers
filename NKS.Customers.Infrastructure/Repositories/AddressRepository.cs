using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NKS.Customers.Core.Entities;
using NKS.Customers.Core.Interfaces;

namespace NKS.Customers.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> ListActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
