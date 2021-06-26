using Microsoft.Extensions.DependencyInjection;
using NKS.Customers.Core.Services.User;

namespace NKS.Customers.Core.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IUserService, UserService>();
        }
    }
}