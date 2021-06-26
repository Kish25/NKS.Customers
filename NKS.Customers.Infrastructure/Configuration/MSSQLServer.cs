using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace NKS.Customers.Infrastructure.Configuration
{
    public static class MSSQLServer
    {
        public static IServiceCollection AddSqlServer(
            this IServiceCollection services,
            string connString)
        {
            return services.AddTransient(
                (Func<IServiceProvider, IDbConnection>) (sp =>
                    (IDbConnection) new SqlConnection(connString)));
        }
    }
}