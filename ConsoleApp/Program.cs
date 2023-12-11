// See https://aka.ms/new-console-template for more information
using ConsoleApp;

Console.WriteLine("Hello, World!");

DatabaseManager databaseManager = new DatabaseManager();

// Load data from the selected data source 
databaseManager.ProductRepository.LoadData();


// Insert a new product
databaseManager.ProductRepository.InsertRecord();

// Update an existing product
databaseManager.ProductRepository.UpdateRecord();

// Delete a product
databaseManager.ProductRepository.DeleteRecord();

// Print product expiration date for a specific product history
if (databaseManager.ProductsPriceHistories.Count > 0)
{
    ProductHistory productHistory = databaseManager.ProductsPriceHistories[0];
    productHistory.PrintExpirationDate();
}

var query1 = from product in databaseManager.Products
             where product.ListPrice > 100
             select product;

var query2 = databaseManager.Products.Where(product => product.ListPrice > 100);




Console.ReadLine();
    
