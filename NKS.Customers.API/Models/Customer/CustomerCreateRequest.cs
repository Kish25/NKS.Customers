using System;
using System.ComponentModel.DataAnnotations;

namespace NKS.Customers.API.Models.Customer
{
    public class CustomerCreateRequest
    {
        public string Title { get; set; }

        [Required(ErrorMessage = "Forename is mandatory")]
        public string Forename { get; set; }

        public string Initials { get; set; }

        [Required(ErrorMessage = "Surname is mandatory")]
        public string Surname { get; set; }

        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Mobile number required.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        public int Status { get; set; }

        [Required] public string Address1  { get; set; }
        public            string Address2  { get; set; }
        public            string Address3  { get; set; }
        public            string Town      { get; set; }
        public            string County    { get; set; }
        public            string Country   { get; set; }
        [Required] public string Postcode  { get; set; }
        public            bool   IsCurrent { get; set; }
    }
}
