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

        public async Task CreateAsync(Customer customer)
        {
            try
            {
                await _connection.ExecuteAsync(Queries.Customers.Create, customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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


        public async Task<IEnumerable<Customer>> ListAllByStatusAsync(bool status)
        {
            if (status)
                return await _connection.QueryAsync<Customer>(Queries.Customers.GetAllByStatus,
                    new
                    {
                        Status = status
                    });
            return await _connection.QueryAsync<Customer>(Queries.Customers.GetAll);
        }

        public Task ChangeNameAsync(Customer customer)
        {
            //example use case
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Customers.Delete,
                new
                {
                    Id = id
                });
        }

        public async Task MarkAsActiveAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Customers.SetStatus,
                new
                {
                    Status = 1
                });
        }

        public async Task MarkAsNotActiveAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Customers.SetStatus,
                new
                {
                    Status = 0
                });
        }

        public async Task MarkAsDeletedAsync(Guid id)
        {
            await _connection.ExecuteAsync(Queries.Customers.MarkAsNull,
                new
                {
                    Id = id
                });
        }
    }
}
