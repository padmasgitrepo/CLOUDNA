using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace CustomerApi.Service
{
	public class Address
    {
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string town { get; set; }
        public string postCode { get; set; }
        public Address()
		{
		}
        public String Addres(string HouseNo,string Street, string Town, string PostalCode)
        {
            String address = HouseNo + "," + Street + "," + Town + "," + PostalCode;
            return address;
        }
	}
}

