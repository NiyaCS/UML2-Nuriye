using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML2
{
    public class Store
    {
        MenuCatalog menuCatalog;

        public Store()
        {
            menuCatalog = new MenuCatalog();
        }
        public void Test()
        {
            Pizza p = new Pizza() { Number = 1, Name = "Carbonara", Price = 70 };
            menuCatalog.Create(p);

            p = new Pizza() { Number = 2, Name = "Pizza al Pesto", Price = 99 };
            menuCatalog.Create(p);

            p = new Pizza() { Number = 3, Name = "Boscaiola", Price = 120 };
            menuCatalog.Create(p);

            menuCatalog.PrintMenu();

          

        }

        public void Run()
        {
            new UserDialog(menuCatalog).Run();
        }
    }
}