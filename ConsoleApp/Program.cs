// See https://aka.ms/new-console-template for more information
using ConsoleApp;

DatabaseManager databaseManager = new DatabaseManager();

// Load data from the selected data source
databaseManager.ProductRepository.LoadData();

bool exit = false;

while (!exit)
{
    Console.WriteLine("1. View Products");
    Console.WriteLine("2. Insert Product");
    Console.WriteLine("3. Update Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ViewProducts(databaseManager);
            break;

        case "2":
            InsertProduct(databaseManager);
            break;

        case "3":
            UpdateProduct(databaseManager);
            break;

        case "4":
            DeleteProduct(databaseManager);
            break;

        case "5":
            exit = true;
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
    

    static void ViewProducts(DatabaseManager databaseManager)
{
    Console.WriteLine("Products:");
    foreach (var product in databaseManager.Products)
    {
        Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, List Price: {product.ListPrice}");
    }
    Console.WriteLine();
}

static void InsertProduct(DatabaseManager databaseManager)
{
    Console.Write("Enter product name: ");
    string name = Console.ReadLine();

    Console.Write("Enter list price: ");
    double listPrice;
    if (double.TryParse(Console.ReadLine(), out listPrice))
    {
        // Assuming other properties are needed for a complete product
        Product newProduct = new Product
        {
            ProductId = databaseManager.ProductRepository.GetNextProductId(),

            Name = name,
            ListPrice = listPrice,
            // Set other properties accordingly
        };

        databaseManager.Products.Add(newProduct);
        Console.WriteLine("Product added successfully.");
    }
    else
    {
        Console.WriteLine("Invalid list price. Please enter a valid number.");
    }
}

static void UpdateProduct(DatabaseManager databaseManager)
{
    Console.Write("Enter product ID to update: ");
    if (int.TryParse(Console.ReadLine(), out int productId))
    {
        Product productToUpdate = databaseManager.Products.Find(p => p.ProductId == productId);

        if (productToUpdate != null)
        {
            Console.Write("Enter new product name: ");
            productToUpdate.Name = Console.ReadLine();

            Console.Write("Enter new list price: ");
            double newListPrice;
            if (double.TryParse(Console.ReadLine(), out newListPrice))
            {
                productToUpdate.ListPrice = newListPrice;
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid list price. Update failed.");
            }
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid product ID. Please enter a valid number.");
    }
}

static void DeleteProduct(DatabaseManager databaseManager)
{
    Console.Write("Enter product ID to delete: ");
    if (int.TryParse(Console.ReadLine(), out int productId))
    {
        Product productToDelete = databaseManager.Products.Find(p => p.ProductId == productId);

        if (productToDelete != null)
        {
            databaseManager.Products.Remove(productToDelete);
            Console.WriteLine("Product deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid product ID. Please enter a valid number.");
    }
}