using System.Threading.Tasks;

namespace NKS.Customers.Core.Services.User
{
    public class UserService : IUserService
    {
        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            return await Task.FromResult(true);
            //username.Equals("me") && password.Equals("P@55W0Rd");
        }
    }
}