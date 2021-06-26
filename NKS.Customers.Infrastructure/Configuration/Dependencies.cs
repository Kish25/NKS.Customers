using Microsoft.Extensions.DependencyInjection;

namespace NKS.Customers.Infrastructure.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, string sqlConnectionString)
        {
            return services
                .AddSqlServer(sqlConnectionString);
        }
    }
}
