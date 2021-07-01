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

        public async Task DeleteAllForCustomerAsync(Guid customerId)
        {
            await _connection.ExecuteAsync(Queries.Address.DeleteAll,
                new
                {
                    CustomerId = customerId
                });
        }

        public async Task MarkAsPrimaryAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Address.MarkAsCurrent,
                new
                {
                    Id = id
                });
        }

        public async Task MarkPrimaryToSecondaryAsync(Guid customerId)
        {
            await _connection.ExecuteAsync(Queries.Address.MarlAllAsNotCurrent,
                new
                {
                    CustomerId = customerId
                });
        }

        public async Task CreateAsync(Address address)
        {
            try
            {
                await _connection.ExecuteAsync(Queries.Address.Create, address);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Address>> GetAllByCustomerIdAsync(Guid customerId)
        {
            return await _connection.QueryAsync<Address>(Queries.Address.GetAllByCustomer,
                new
                {
                    CustomerId = customerId
                });
        }
    }
}