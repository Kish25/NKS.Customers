using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using NKS.Customers.Core.Entities;
using NKS.Customers.Core.Interfaces;

namespace NKS.Customers.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _connection;

        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var customer = await _connection.QueryFirstOrDefaultAsync<Customer>
            (Queries.Customers.GetById,
                new
                {
                    Id = id
                });

            return customer;
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
