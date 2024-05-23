using System;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.Runtime.Serialization;

namespace CustomerApi.Models
{
    [DataContract]
    public class OrderItems
	{
        [DataMember(Name = "OrderItemId")]
        public int orderitemid { get; set; }
        [DataMember(Name = "OrderId")]
        public int orderid { get; set; }
        [DataMember(Name = "ProductId")]
        public int productid { get; set; }
        [DataMember(Name = "Quantity")]
        public int quantity { get; set; }
        [DataMember(Name = "Price")]
        public float price { get; set; }
        public OrderItems()
		{
		}
	}
}

