using System;

namespace NKS.Customers.Core.Entities
{
    public class Contact : BaseEntity
    {
        public Guid   CustomerId { get; set; }
        public string Type       { get; set; } // Mobile, Email , Twitter ....
        public string Details    { get; set; }
    }
}
