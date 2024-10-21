using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using ProduktKatalog.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ProduktKatalog.Services
{

    public class ProductService
    {
        
        
        public List<Product> products;
        public int nextId;

        public ProductService()
        {
            products = new List<Product>();
            nextId = 1;
        }

       

        public void AddProduct(string name, decimal price)
        {
            products.Add(new Product { Id = nextId++, Name = name, Price = price });
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void SaveToFile(string fileName)
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            using var sw = new StreamWriter(fileName);
            sw.WriteLine(json);
        }

        public void LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using var sr = new StreamReader(fileName);
                products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd())!;

           
            }
        }

        public int Count
        {
            get { return products.Count; }
        }
    }
}

