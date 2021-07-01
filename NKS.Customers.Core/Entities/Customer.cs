using System;

namespace NKS.Customers.Core.Entities
{
	public class Customer : BaseEntity
	{
		public string   Title        { get; set; }
		public string   Forename     { get; set; }
		public string   Initials     { get; set; }
		public string   Surname      { get; set; }
		public DateTime DateOfBirth  { get; set; }
		public string   MobileNumber { get; set; }
		public string   Email        { get; set; }
		public string   HashedEmail  { get; set; }
		public int      Status       { get; set; }
	}
}