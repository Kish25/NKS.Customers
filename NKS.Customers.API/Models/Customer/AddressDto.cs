using System;
using System.ComponentModel.DataAnnotations;

namespace NKS.Customers.API.Models.Customer
{
    public class AddressDto
    {
        public            Guid   Id         { get; set; }
        public            Guid   CustomerId { get; set; }
        [Required] public string Address1   { get; set; }
        public            string Address2   { get; set; }
        public            string Town       { get; set; }
        public            string County     { get; set; }
        public            string Country    { get; set; }
        [Required] public string Postcode   { get; set; }
        public            bool   IsCurrent  { get; set; }
    }
}