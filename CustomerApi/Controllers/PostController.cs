using System;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using CustomerApi.Models;
using CustomerApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController
    {
        private readonly IConfiguration _configuration;
        private SqlConnection conn;
        private SqlDataAdapter adp;
        [HttpPost]
        public List<KeyValuePair<string,object>> Post([FromBody] string user, int id)
        {
            DataTable dt = new DataTable();
            DataTable order = new DataTable();
            DataTable product = new DataTable();
            List<String> Name = new List<String>();
            conn = new SqlConnection("data source=53.87.145.24,1480;initial catalog=SMS_TEST;user id=SMSAPPUSER; password=MLIT@2011");
            string query = "Select CustomerId from Customer where Email='"+user+"'";
            int Cusid;
                adp= new SqlDataAdapter(query, conn);
            adp.Fill(dt);
            Cusid = (int)dt.Rows[1]["CustomerId"];
            if (Cusid == id)
            {
                query = "Select firstName,LastName,HouseNo,Street,Town,PostalCode from Customers where CustomerId="+id;
                adp = new SqlDataAdapter(query, conn);
                adp.Fill(dt);
                foreach(DataRow cus in dt.Rows)
                {
                    Name.Add(cus.ToString());
                }
                List<KeyValuePair<string, string>> customerName = new List<KeyValuePair<string, string>>();
                String[] ar= Name.ToArray();
                customerName.Add(new KeyValuePair<string, string>("FirstName", ar[0]));
                customerName.Add(new KeyValuePair<string, string>("LastName", ar[1]));

                Address ad = new Address();
                ad.Addres(ar[2], ar[3], ar[4], ar[5]);

                query = "Select OrderId,OrderDate,DeliveryExpected from Orders where CustomerId="+id;
                adp = new SqlDataAdapter(query, conn);
                adp.Fill(order);
                for (int i=0;i<order.Rows.Count;i++)
                { 
                    query = "Select ProductId,Quantity,Price from OrderItems where OrderId=" + order.Rows[i]["orderId"];
                    adp = new SqlDataAdapter(query, conn);
                    adp.Fill(product);
                }

                for (int i= 0; i < product.Rows.Count; i++)
                {
                    query = "Select ProductName from Product where ProductId=" + product.Rows[i]["ProductId"];
                    adp = new SqlDataAdapter(query, conn);
                    adp.Fill(product);
                }
                OrderItem orderItem = new OrderItem();
                List<KeyValuePair<string, string>> order_Item = new List<KeyValuePair<string, string>>();
                for(int i=0;i<product.Rows.Count;i++)
                {
                    order_Item=orderItem.ProductDetails((string)product.Rows[i]["ProductName"], (int)order.Rows[i]["Quantity"], (float)order.Rows[i]["Price"]);
                }
                ResultOrder resultOrder = new ResultOrder();
                resultOrder.Order((int)order.Rows[1]["orderId"], (DateTime)order.Rows[1]["OrderDate"], ad, orderItem, (DateTime)order.Rows[1]["DeliveryExpected"]);

                List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();
                result.Add(new KeyValuePair<string, object>("CustomerName", customerName));
                result.Add(new KeyValuePair<string, object>("Orders", resultOrder));
                return result;
            }
            else
            {
                List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();
                result.Add(new KeyValuePair<string, object>("Error", new String("Invalid request")));
                return result;
            }
            
        }
        public PostController()
        {
        }
    }
}