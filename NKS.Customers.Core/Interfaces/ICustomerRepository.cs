using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NKS.Customers.Core.Entities;

namespace NKS.Customers.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task<Customer> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> ListAllByStatusAsync(bool isActive);
        Task ChangeNameAsync(Customer customer);
        Task DeleteAsync(Guid id);
        Task MarkAsActiveAsync(Guid id);
        Task MarkAsNotActiveAsync(Guid id);
        Task MarkAsDeletedAsync(Guid id);
    }
}