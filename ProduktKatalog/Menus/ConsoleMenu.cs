using ProduktKatalog.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduktKatalog.Menus
{
    public class ConsoleMenu
    {
        private ProductService productService;
        private string fileName = "products.json";

        public ConsoleMenu(ProductService service)
        {
            productService = service;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n1. Create Product");
                Console.WriteLine("2. Display Product");
                Console.WriteLine("3. Save to File");
                Console.WriteLine("4. Load from File");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string Choice = Console.ReadLine();

                if (Choice == "2")
                {
                    Console.WriteLine("Would you like to view specific user?");
                    Console.ReadLine(); 

                }

                switch (Choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        DisplayProducts();
                        break;
                    case "3":
                        SaveToFile();
                        break;
                    case "4":
                        LoadFromFile();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        private void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name!.ToLower());
            Console.Write("Enter product price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                productService.AddProduct(name, price);
                Console.WriteLine("Product added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid price. Product not added.");
            }
        }

        private void DisplayProducts()
        {
            var products = productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
            }
        }

        private void SaveToFile()
        {
            productService.SaveToFile(fileName);
            Console.WriteLine("Products saved to file.");
        }

        private void LoadFromFile()
        {
            productService.LoadFromFile(fileName);
            Console.WriteLine("Products loaded from file.");
        }
    }
}
