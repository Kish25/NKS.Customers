using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NKS.Customers.Core.Entities;

namespace NKS.Customers.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task CreateAsync(Address address);
        Task<IEnumerable<Address>> GetAllByCustomerIdAsync(Guid customerId);
        Task MarkPrimaryToSecondaryAsync(Guid customerId);
        Task MarkAsPrimaryAsync(Guid customerId);
        Task DeleteAllForCustomerAsync(Guid customerId);
    }
}