using System;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace CustomerApi.Models
{
    [DataContract]
    public class Orders
	{
        [DataMember(Name = "OrderId")]
        public int orderid { get; set; }
        [DataMember(Name = "CustomerId")]
        public int customerId { get; set; }
        [DataMember(Name = "OrderDate")]
        public DateTime orderDate { get; set; }
        [DataMember(Name = "DeliveryExpected")]
        public DateTime deliveryExpected { get; set; }
        [DataMember(Name = "ContainsGift")]
        public Boolean containsgift { get; set; }
        public Orders()
		{
		}
	}
}

