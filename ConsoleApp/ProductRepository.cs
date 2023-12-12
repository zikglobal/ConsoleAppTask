using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ProductRepository : ICrudRepository
    {
        private DatabaseManager databaseManager;
        private DataLoader dataLoader;

        public ProductRepository(DatabaseManager dbManager)
        {
            databaseManager = dbManager;
            dataLoader = new DataLoader();

        }


        public void DeleteRecord()
        {
            // Implement record deletion logic
            

            if (databaseManager.Products.Count > 0)
            {
                Product productToDelete = databaseManager.Products[0];
                databaseManager.Products.Remove(productToDelete);
            }
        }

        public void InsertRecord()
        {
            

            Product newProduct = new Product
            {
                ProductId = GetNextProductId(),
                Name = "New Product",
                
            };

            databaseManager.Products.Add(newProduct);
        }

        public void LoadData()
        {
           

            // Load products
            List<Product> products = dataLoader.LoadProductsFromFile(databaseManager.ProductFileName);
            databaseManager.Products = products;

            // Load product histories
            List<ProductHistory> productHistories = dataLoader.LoadProductHistoriesFromFile(databaseManager.HistoriesFileName);
            databaseManager.ProductsPriceHistories = productHistories;
        }

        public void UpdateRecord()
        {
            

            if (databaseManager.Products.Count > 0)
            {
                Product productToUpdate = databaseManager.Products[0];
                productToUpdate.Name = "Updated Product";
                
            }
        }

        public int GetNextProductId()
        {
            return databaseManager.Products.Count + 1;
        }
    }
}
