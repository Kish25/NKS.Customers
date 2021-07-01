using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using NKS.Customers.Core.Entities;
using NKS.Customers.Core.Interfaces;

namespace NKS.Customers.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDbConnection _connection;

        public AddressRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async void CreateAsync(Address address)
        {
            await _connection.ExecuteAsync(Queries.Address.Create, address);
        }

        public async void DeleteAllForCustomerAsync(Guid customerId)
        {
            await _connection.ExecuteAsync(Queries.Address.DeleteAll,
                new
                {
                    CustomerId = customerId
                });
        }

        public async Task<IEnumerable<Address>> GetAllByCustomerIdAsync(Guid customerId)
        {
            return await _connection.QueryAsync<Address>(Queries.Address.GetAllByCustomer,
                new
                {
                    CustomerId = customerId
                });
        }

        public async void MarkAsPrimaryAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Address.MarkAsCurrent,
                new
                {
                    Id = id
                });
        }

        public async void MarkPrimaryToSecondaryAsync(Guid customerId)
        {
            await _connection.ExecuteAsync(Queries.Address.MarlAllAsNotCurrent,
                new
                {
                    CustomerId = customerId
                });
        }
    }
}
