using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NKS.Customers.Core.Entities;

namespace NKS.Customers.Core.Interfaces
{
    public interface ICustomerRepository
    {
        void CreateAsync(Customer customer);
        Task<Customer> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> ListAllAsync();
        Task<IEnumerable<Customer>> ListAllActiveAsync();
        void ChangeNameAsync(Customer customer);
        void DeleteAsync(Guid id);
        void MarkAsActiveAsync(Guid id);
        void MarkAsNotActiveAsync(Guid id);
    }
}