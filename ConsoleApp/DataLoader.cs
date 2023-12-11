using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DataLoader
    {
        public List<Product> LoadProductsFromFile(string fileName)
        {
            List<Product> products = new List<Product>();

            try
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines.Skip(1)) 
                {
                    string[] values = line.Split(',');

                    Product product = new Product
                    {
                        ProductId = int.Parse(values[0]),
                        Name = values[1],
                        
                    };

                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading products: {ex.Message}");
            }

            return products;
        }

        public List<ProductHistory> LoadProductHistoriesFromFile(string fileName)
        {
            List<ProductHistory> histories = new List<ProductHistory>();

            try
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines.Skip(1)) 
                {
                    string[] values = line.Split(',');

                    ProductHistory history = new ProductHistory
                    {
                        ProductId = int.Parse(values[0]),
                        StartDate = DateTime.Parse(values[1]),
                        EndDate = DateTime.Parse(values[2]),
                        ListPrice = double.Parse(values[3]),
                        
                    };

                    histories.Add(history);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading product histories: {ex.Message}");
            }

            return histories;
        }
    }
}
