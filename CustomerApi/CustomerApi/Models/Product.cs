using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace CustomerApi.Models
{
	[DataContract]
	public class Product
	{
        [DataMember(Name = "ProductId")]
        public int productId { get; set; }
        [DataMember(Name = "ProductName")]
        public string productName { get; set; }
        [DataMember(Name = "Colour")]
        public string colour { get; set; }
        [DataMember(Name = "Size")]
        public int size { get; set; }
        public Product()
		{
		}
	}
}

