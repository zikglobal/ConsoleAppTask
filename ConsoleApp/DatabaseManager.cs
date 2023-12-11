using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DatabaseManager
    {
        public string DirctoryPath { get; set; }
        public string ProductFileName { get; set; }
        public string HistoriesFileName { get; set; }
        public List<Product>Products { get; set; }
        public List<ProductHistory>ProductsPriceHistories { get; set; }
        public ProductRepository ProductRepository { get; }

        public DatabaseManager()
        {
            Products = new List<Product>();
            ProductsPriceHistories = new List<ProductHistory>();
            ProductRepository = new ProductRepository(this);
        }
    }
}
