using System;

namespace NKS.Customers.Core.Entities
{
    public class Address : BaseEntity
    {
        public Guid   CustomerId { get; set; }
        public string Address1   { get; set; }
        public string Address2   { get; set; }
        public string Address3   { get; set; }

        public string Town       { get; set; }
        public string County     { get; set; }
        public string Country    { get; set; }
        public string Postcode   { get; set; }
        public bool   IsCurrent  { get; set; }
    }
}