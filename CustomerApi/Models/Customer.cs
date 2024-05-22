using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace CustomerApi.Models
{
    [DataContract]
	public class Customer
	{
        [DataMember(Name ="CustomerId")]
		public int customerid { get; set; }
        [DataMember(Name = "FirstName")]
        public string firstName { get; set; }
        [DataMember(Name = "LastName")]
        public string lastName { get; set; }
        [DataMember(Name = "Email")]
        public string email { get; set; }
        [DataMember(Name = "HouseNo")]
        public string HouseNo { get; set; }
        [DataMember(Name = "Street")]
        public string Street { get; set; }
        [DataMember(Name = "Town")]
        public string town { get; set; }
        [DataMember(Name = "PostCode")]
        public string postCode { get; set; }
        public Customer()
		{
		}
	}
}

