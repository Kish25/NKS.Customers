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
            _connection = connection ?? throw new ArgumentException("Active connection is required to execute quries.");
        }

        public async void CreateAsync(Customer customer)
        {
            await _connection.ExecuteAsync(Queries.Customers.Create, customer);
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


        public async Task<IEnumerable<Customer>> ListAllAsync()
        {
            return await _connection.QueryAsync<Customer>(Queries.Customers.GetAll);
        }

        public async Task<IEnumerable<Customer>> ListAllActiveAsync()
        {
            return await _connection.QueryAsync<Customer>(Queries.Customers.GetAllActive);
        }

        public void ChangeNameAsync(Customer customer)
        {
            //example use case
            throw new NotImplementedException();
        }

        public async void DeleteAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Customers.Delete,
                new
                {
                    Id = id
                });
        }

        public async void MarkAsActiveAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Customers.SetStatus,
                new
                {
                    Status = 1
                });
        }

        public async void MarkAsNotActiveAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Customers.SetStatus,
                new
                {
                    Status = 0
                });
        }
    }
}
