using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.Extensions
{
    public static class ListExtension
    {
        public static List<Product> GetProducts(this List<Product> products)
            => Products.ProductList;
        
        public static List<Customer> GetCustomers(this List<Customer> customers)
            => Customers.CustomerList;

    }
}
