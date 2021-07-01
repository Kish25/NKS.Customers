using Microsoft.Extensions.DependencyInjection;
using NKS.Customers.Core.Interfaces;
using NKS.Customers.Infrastructure.Repositories;

namespace NKS.Customers.Infrastructure.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, string sqlConnectionString)
        {
            return services
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<IAddressRepository, AddressRepository>()
                .AddSqlServer(sqlConnectionString);
        }
    }
}
