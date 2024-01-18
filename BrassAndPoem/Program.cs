
using System.Numerics;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Big Ol' Book of Poems",
        Price = 14.99M,
        ProductTypeId = 1,

    },
    new Product()
    {
        Name = "Timmy's Trombone",
        Price = 200.00M,
        ProductTypeId = 2,

    },
    new Product()
    {
        Name = "Poetry for Dumbos",
        Price = 19.99M,
        ProductTypeId = 1,

    },
    new Product()
    {
        Name = "Barely a Baritone",
        Price = 666.66M,
        ProductTypeId = 2,

    },
    new Product()
    {
        Name = "Worst Poems to Read on an Escalator",
        Price = 9.99M,
        ProductTypeId = 1,
    }
};

List<ProductType> producttypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Poetry",
        Id = 1,

    },
    new ProductType()
    {
        Title = "Brass Instruments",
        Id = 2

    },
};

string greeting = @"Welcome to BrassAndPoem
Where brass meets poetry!" + Environment.NewLine;

string keystroke = "Press any key to continue...";

Console.WriteLine(greeting);

DisplayMenu();

void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
        Console.WriteLine
        (Environment.NewLine + "Choose an option:\n\n" +
                  "1. Display All Products\n" +
                  "2. Delete a Product\n" +
                  "3. Add a New Product\n" +
                  "4. Update Product Properties\n" +
                  "5. Exit\n");

        choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayAllProducts(products, producttypes);
        }
        else if (choice == "2")
        {
            DeleteProduct(products);
        }
        else if (choice == "3")
        {
            AddProduct(products, producttypes);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, producttypes);
        }
        else if (choice == "5")
        {
            Console.WriteLine("\n\nSee that brass bassoon!");
            break;
        }
    }

}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nDisplaying All Products:\n");

    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];

        string productTypeTitle = productTypes
            .Where(pt => pt.Id == product.ProductTypeId)
            .Select(pt => pt.Title)
            .FirstOrDefault();

        int productNumber = i + 1;

        Console.WriteLine(@$"
Product Number: {productNumber}
Name: {product.Name}
Price: {product.Price:C} 
Product Type: {productTypeTitle}");
    }

    Console.WriteLine("\n" + keystroke);
    Console.ReadKey(true);
}

void DeleteProduct(List<Product> products)
{
    Console.WriteLine("\nDeleting a Product:\n");

    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        int productNumber = i + 1;
        Console.WriteLine($"Product Number: {productNumber}, Name: {product.Name}, Price: {product.Price:C}");
    }

    Console.WriteLine("\nEnter the product number you want to delete:");
    if (int.TryParse(Console.ReadLine(), out int productNumberToDelete) && productNumberToDelete >= 1 && productNumberToDelete <= products.Count)
    {
       
        int indexToDelete = productNumberToDelete - 1;

        Product productToDelete = products[indexToDelete];
        Console.WriteLine($"\nYou've selected to delete the following product:\n" +
                          $"Product Number: {productNumberToDelete}, Name: {productToDelete.Name}, Price: {productToDelete.Price:C}\n");

        Console.WriteLine("Do you want to proceed with the deletion? (Y/N)");
        string confirmation = Console.ReadLine().Trim().ToUpper();

        if (confirmation == "Y")
        {
            products.Remove(productToDelete);
            Console.WriteLine($"\nProduct '{productToDelete.Name}' at product number {productNumberToDelete} has been deleted.\n");
        }
        else
        {
            Console.WriteLine("\nDeletion canceled. No product deleted.\n");
        }
    }
    else
    {
        Console.WriteLine("\nInvalid product number. No product deleted.\n");
    }

    Console.WriteLine(keystroke);
    Console.ReadKey(true);
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nAdding a New Product:\n");

    string productName;
    do
    {
        Console.WriteLine("Enter the name of the new product:");
        productName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("Product name cannot be blank. Please enter a valid name.");
        }

    } while (string.IsNullOrWhiteSpace(productName));

    decimal productPrice;
    do
    {
        Console.WriteLine("Enter the price of the new product:");
    } while (!decimal.TryParse(Console.ReadLine(), out productPrice) || productPrice < 0);

    Console.WriteLine("\nAvailable Product Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        ProductType productType = productTypes[i];
        Console.WriteLine($"{i + 1}. {productType.Title}");
    }

    int selectedProductTypeIndex;
    do
    {
        Console.WriteLine("\nEnter the number corresponding to the product type:");
    } while (!int.TryParse(Console.ReadLine(), out selectedProductTypeIndex) ||
             selectedProductTypeIndex < 1 ||
             selectedProductTypeIndex > productTypes.Count);

    ProductType selectedProductType = productTypes[selectedProductTypeIndex - 1];
    Product newProduct = new Product
    {
        Name = productName,
        Price = productPrice,
        ProductTypeId = selectedProductType.Id
    };

    products.Add(newProduct);

    Console.WriteLine($"\nNew product '{productName}' has been added to the list.\n");
    Console.WriteLine(keystroke);
    Console.ReadKey(true);
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nUpdating Product Properties:\n");

    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        Console.WriteLine($"Product Number: {i + 1}, Name: {product.Name}, Price: {product.Price:C}");
    }

    Console.WriteLine("\nEnter the product number you want to update (or 0 to cancel):");
    if (int.TryParse(Console.ReadLine(), out int selectedProductNumber) && selectedProductNumber >= 1 && selectedProductNumber <= products.Count)
    {
        Product productToUpdate = products[selectedProductNumber - 1];

        Console.WriteLine("\nEnter the updated name (press enter to leave unchanged):");
        string updatedName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(updatedName))
        {
            productToUpdate.Name = updatedName;
        }

        decimal updatedPrice;
        do
        {
            Console.WriteLine("Enter the updated price (press enter to leave unchanged):");
        } while (!decimal.TryParse(Console.ReadLine(), out updatedPrice) && updatedPrice < 0);
        productToUpdate.Price = updatedPrice;

        Console.WriteLine("\nAvailable Product Types:");
        for (int i = 0; i < productTypes.Count; i++)
        {
            ProductType productType = productTypes[i];
            Console.WriteLine($"{i + 1}. {productType.Title}");
        }

        int selectedProductTypeIndex;
        do
        {
            Console.WriteLine("\nEnter the number corresponding to the updated product type (press enter to leave unchanged):");
        } while (!int.TryParse(Console.ReadLine(), out selectedProductTypeIndex) ||
                 selectedProductTypeIndex < 1 ||
                 selectedProductTypeIndex > productTypes.Count);

        if (selectedProductTypeIndex > 0)
        {
            productToUpdate.ProductTypeId = productTypes[selectedProductTypeIndex - 1].Id;
        }

        Console.WriteLine($"\nProduct at product number {selectedProductNumber} has been updated.\n");
    }
    else if (selectedProductNumber == 0)
    {
        Console.WriteLine("\nUpdate canceled. No product updated.\n");
    }
    else
    {
        Console.WriteLine("\nInvalid product number. No product updated.\n");
    }

    Console.WriteLine(keystroke);
    Console.ReadKey(true);
}

// don't move or change this!
public partial class Program { }