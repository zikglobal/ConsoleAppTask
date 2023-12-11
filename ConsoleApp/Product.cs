using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public double StandardCost { get; set; }
        public double ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
        public DateTime SellSatrtDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<ProductHistory>ProductHistories { get; set; }


        public Product()
        {
            ProductHistories = new List<ProductHistory>();
        }

    }
}
