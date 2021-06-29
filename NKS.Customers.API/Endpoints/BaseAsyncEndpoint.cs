using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NKS.Customers.API.Endpoints
{
  [ApiController]
  public abstract class BaseAsyncEndpoint<TRequest, TResponse> : Controller
  {
    public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request);
  }

  [ApiController]
  public abstract class BaseAsyncEndpoint<TResponse> : Controller
  {
    public abstract Task<ActionResult<TResponse>> HandleAsync();
  }

  //[ApiController]
  //public abstract class BaseAsyncEndpoint<Guid, TResponse> : Controller
  //{
  //  public abstract Task<ActionResult<TResponse>> HandleAsync(Guid id);
  //}
}
