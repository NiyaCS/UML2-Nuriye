using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML2
{

    public class UserDialog
    {
        MenuCatalog _menuCatalog;
        public UserDialog(MenuCatalog menuCatalog)
        {
            _menuCatalog = menuCatalog;
        }

        Pizza GetNewPizza()
        {
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("| Opret Pizza          |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Skriv dit navn: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Skriv prisen: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Skriv pizza nummer: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            return pizzaItem;
        }
        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| BIGMAMMA PIZZAMENU |");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Muligheder:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Indtast mulighed#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Exit",
                "1. Opret ny pizza",
                "2. Print menu",
                "3. Andre muligheder"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;
                    case 1:
                        try
                        {
                            Pizza pizza = GetNewPizza();
                            _menuCatalog.Create(pizza);
                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Ingen pizza oprettet");
                        }
                        Console.Write("Tryk på enhver knap til at fortsætte");
                        Console.ReadKey();
                        break;
                    case 2:
                        _menuCatalog.PrintMenu();
                        Console.Write("Tryk på enhver knap til at fortsætte");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine($"You selected: {mainMenulist[MenuChoice]}");
                        Console.Write("Tryk på enhver knap til at fortsætte");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Tryk på enhver knap til at fortsætte");
                        Console.ReadKey();
                        break;
                }
            }

        }
    }
}