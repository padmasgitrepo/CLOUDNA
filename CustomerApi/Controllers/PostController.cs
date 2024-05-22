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
        public IActionResult Post([FromBody] string user, int id)
        {
            DataTable dt = new DataTable();
            DataTable order = new DataTable();
            DataTable product = new DataTable();
            List<String> Name = new List<String>();
            conn = new SqlConnection("data source=53.87.145.24,1480;initial catalog=SMS_TEST;user id=SMSAPPUSER; password=MLIT@2011");
            string query = "Select CustomerId from Customer where Email='"+user+"'";
            int Cusid=new SqlDataAdapter(query, conn);
            if (Cusid == id)
            {
                query = "Select firstName,LastName,HouseNo,Street,Town,PostalCode from Customers where CustomerId="+id;
                adp = new SqlDataAdapter(query, conn);
                adp.Fill(dt);
                foreach(DataRow cus in dt.Rows)
                {
                    Name.Add(cus);
                }
                String[] ar= Name.ToArray();
                Address ad = new Address();
                ad.Addres(ar[2], ar[3], ar[4], ar[5]);
                query = "Select OrderId,OrderDate,DeliveryExpected from Orders where CustomerId="+id;
                adp = new SqlDataAdapter(query, conn);
                adp.Fill(order);
                OrderItem oi = new OrderItem();
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                list=oi.ProductDetails()


                for (int i=0;i<order.Rows.Count;i++)
                {
                    query = "Select ProductId,Quantity,Price from OrderItems where OrderId=" + id;
                    adp = new SqlDataAdapter(query, conn);
                    adp.Fill(product);
                }

                foreach(DataRow row in product.Rows)
                {
                    query = "Select ProductName from Product where ProductId=" + product["ProductId"];
                    adp = new SqlDataAdapter(query, conn);
                    adp.Fill(product);
                }

            }
            else
            {
                //incorrectrequest
            }
            
        }
        public PostController()
        {
        }
    }
}