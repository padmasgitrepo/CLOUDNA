using System;
namespace CustomerApi.Service
{
	public class ResultOrder
	{
		public int orderno;
		public DateTime orderdate;
		public Address address;
		public OrderItem OrderItem;
		public DateTime delivery_expected;
		public List<KeyValuePair<string, object>> Order(int orderno, DateTime orderdate, Address address, OrderItem orderitem, DateTime Delivery_Expected)
		{
			List<KeyValuePair<string, object>> result_order = new List<KeyValuePair<string, object>>();
			result_order.Add(new KeyValuePair<string, object>("OrderNumber", orderno));
            result_order.Add(new KeyValuePair<string, object>("OrderDate", orderdate));
            result_order.Add(new KeyValuePair<string, object>("Delivery Address", address));
            result_order.Add(new KeyValuePair<string, object>("Order Items", orderitem));
            result_order.Add(new KeyValuePair<string, object>("Expected Date", Delivery_Expected));
			return result_order;
        }
        public ResultOrder()
		{
		}
	}
}

