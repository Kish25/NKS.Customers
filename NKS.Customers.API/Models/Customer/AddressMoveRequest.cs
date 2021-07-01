using System;
using System.ComponentModel.DataAnnotations;

namespace NKS.Customers.API.Models.Customer
{
    public class AddressMoveRequest
    {
        [Required] public Guid CustomerId { get; set; }
        [Required] public Guid AddressId  { get; set; }
    }
}
