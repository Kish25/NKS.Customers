using System.Threading.Tasks;

namespace NKS.Customers.Core.Services.User
{
    public interface IUserService
    {
        Task<bool> ValidateCredentialsAsync(string username, string password);
    }
}