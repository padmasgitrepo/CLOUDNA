using System;
namespace CustomerApi.Service
{
	public class OrderItem
	{
		public string productName;
		public int quantity;
		public float price;
		public List<KeyValuePair<string, string>> ProductDetails(string productName,int quantity,float price)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("Product", productName));
            list.Add(new KeyValuePair<string, string>("Quantity", quantity.ToString()));
            list.Add(new KeyValuePair<string, string>("PriceEach", (price/quantity).ToString()));
			return list;
        }
		public OrderItem()
		{
		}
	}
}

