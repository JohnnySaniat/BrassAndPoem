
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
            throw new NotImplementedException();
        }
        else if (choice == "2")
        {
            throw new NotImplementedException();
        }
        else if (choice == "3")
        {
            throw new NotImplementedException();
        }
        else if (choice == "4")
        {
            throw new NotImplementedException();
        }
        else if (choice == "5")
        {
            Console.WriteLine("\n\nSee that brass bassoon!");
            break;
        }
    }

}


// don't move or change this!
public partial class Program { }