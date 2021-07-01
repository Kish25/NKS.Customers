using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NKS.Customers.Core.Entities;

namespace NKS.Customers.Core.Interfaces
{
    public interface IAddressRepository
    {
        void CreateAsync(Address address);
        Task<IEnumerable<Address>> GetAllByCustomerIdAsync(Guid customerId);
        void MarkPrimaryToSecondaryAsync(Guid customerId);
        void MarkAsPrimaryAsync(Guid customerId);
        void DeleteAllForCustomerAsync(Guid customerId);
    }
}
