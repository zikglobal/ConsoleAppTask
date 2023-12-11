using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ProductHistory:History
    {
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Double ListPrice { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Product Product { get; set; }

        public override void PrintExpirationDate()
        {
            
            Console.WriteLine($"Product with ID {ProductId} expires on {EndDate}");
        }

    }
}
