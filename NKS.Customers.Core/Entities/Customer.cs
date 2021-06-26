using System;

namespace NKS.Customers.Core.Entities
{
	public class Customer : BaseEntity
	{
		public string Title { get; set; }
		public string Forename { get; set; }
		public string Surname { get; set; }
		public DateTime DateofBirth { get; set; }
		public string MobileNumber { get; set; }
		public string EmailAddress { get; set; }
		public string Status { get; set; }
	}
}