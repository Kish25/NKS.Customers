using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NKS.Customers.Core.Entities;

namespace NKS.Customers.Core.Interfaces
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Task<Customer> GetByIdAsync(Guid id);
        Task<List<Customer>> ListAllAsync();
        Task<List<Customer>> ListActiveAsync();
        Task UpdateAsync<T>(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}