using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class JsonCustomerRepository: ICustomerRepository
    {
        private string url = "http://www.json-generator.com/api/json/get/clgSsbDtDS?indent=2";

        //public JsonCustomerRepository() { }
        public JsonCustomerRepository(IDbContext context) { }

        public ICollection<Customer> GetAllCustomers()
        {
            List<Customer> cus = new List<Customer>();
            string responce;

            using (var WebClient = new WebClient())
            {
                responce = WebClient.DownloadString(url);
            }

            ICollection<Customer> model = JsonConvert.DeserializeObject<List<Customer>>(responce);

            return model;
        }

        public void Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            List<Customer> customers = (List<Customer>)GetAllCustomers();

            Customer model = null;
            foreach (Customer c in customers)
            {
                if (c.Id == id)
                {
                    model = c;
                    break;
                }

            }
            return model;
        }
    }
}