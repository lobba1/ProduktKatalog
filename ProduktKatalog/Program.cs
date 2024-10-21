
using ProduktKatalog.Menus;
using ProduktKatalog.Services;

namespace ProductCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService service = new ProductService();
            ConsoleMenu menu = new ConsoleMenu(service);
            menu.Run();
        }
    }
}