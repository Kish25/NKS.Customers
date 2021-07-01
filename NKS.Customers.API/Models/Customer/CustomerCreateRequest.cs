using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NKS.Customers.API.Models.Customer
{
    public class CustomerCreateRequest
    {
        public string Title { get; set; }

        [Required(ErrorMessage = "Forename is mandatory")]
        public string Forename { get; set; }

        [Required(ErrorMessage = "Surname is mandatory")]
        public string Surname { get; set; }

        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Mobile number required.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        public string        Status  { get; set; }

        public List<Address> Address { get; set; }
    }
}
