using System;
using System.Collections.Generic;

namespace NKS.Customers.Core.Entities
{
	public class Customer : BaseEntity
	{
		public Customer()
		{
			Address = new List<Address>();
		}

		public string   Title        { get; set; }
		public string   Forename     { get; set; }
		public string   Surname      { get; set; }
		public DateTime DateOfBirth  { get; set; }
		public string   MobileNumber { get; set; }
		public string   Email        { get; set; }
		public string   Status       { get; set; }

		public List<Address> Address { get; set; }
	}
}