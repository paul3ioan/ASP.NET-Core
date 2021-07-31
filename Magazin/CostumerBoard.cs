using System;
using MagazinData;
using MagazinData.Entity;
using Microsoft.Extensions.DependencyInjection;
using Magazin.Services.Product;
using System.Collections.Generic;
using Magazin.Services.General1;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Magazin.Services.Users.TypeOfUsers;

using Magazin.Services.Users;
using System.Threading.Tasks;
using MagazinData.Users;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Magazin
{
    public class CostumerBoard
    {
        
        static void SeeItem(ICostumer costumer, enumtype type,string user)
        {
            var produseDeCumparat = new List<ProductDto>();
            int Instance = 0;
            Console.WriteLine($" This is the first page of food\n If you want to get to the previous page press [prev]\n If you want to get to the next page press [next]\n Press [exit] to exit");
            var produse = new List<ProductDto>();
            produse = costumer.GetShowProducts(type, Instance);
            bool ok1 = true;
            int choice;
            while (ok1 == true)
            {
                
                var task1 = Console.ReadLine();
                try
                {
                    choice = Int32.Parse(task1);
                    if (choice >= 1 && choice <= 5)
                    {
                        produseDeCumparat.Add(produse[choice - 1]);
                       // Console.WriteLine("A mers");
                    }
                    else
                    {
                        Console.WriteLine($" Invalid input, try again ");
                        break;
                    }
                }
                catch
                {
                    switch (task1)
                    {
                        case "exit":
                            ok1 = false;
                            break;
                        case "next":
                            produse = costumer.GetShowProducts(type, Instance = Instance + 5);
                            if (produse == null) continue;
                            break;
                        case "prev":
                            produse = costumer.GetShowProducts(type, Instance = Instance - 5);
                            if (produse == null) continue;
                            break;
                        default:
                            {
                                Console.WriteLine($" Invalid input, try again ");
                                break;
                            }
                    }
                }
                Console.WriteLine($"If you re ready press exit");
            }
            costumer.BuyProduct(user, produseDeCumparat);
        }

        static int CheckInput()
        {
            while (true)
            {
                var task = Console.ReadLine();
                int input;
                try
                {
                    input = Int32.Parse(task);
                    if (input < 1)
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                    return input;
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
            }

        }
        public static void CostumerBoardd(IServiceScope scope, string user)
        {
            ICostumer costumer;
            costumer = scope.ServiceProvider.GetService<ICostumer>();

            while (true)
            {
                Console.WriteLine($" Press[1] to add cash to your account\n Press[2] to take cash from your account\n" +
                    $" Press[3] to buy a product\n Press[4] to exit");
                //Console.WriteLine($"Buy product bugged try to solve Repository attach problem");
                var task = Console.ReadLine();
                int input;
                try
                {
                    input = Int32.Parse(task);
                    if (input < 1 || input > 4)
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (input == 4)
                    break;
                if (input == 1)
                {
                    Console.WriteLine($"Write the amount of money you want to add:");
                    int x = CheckInput();
                    costumer.AddCash(user, x);
                    Console.WriteLine($"The change has been done!");
                }
                if (input == 2)
                {
                    Console.WriteLine($"Write the amount of money you want to take:");
                    int x = CheckInput();
                    costumer.AddCash(user, -x);
                    Console.WriteLine($"The change has been done!");
                }
                if (input == 3)
                {                                
                    while (true)
                    {
                        Console.WriteLine($"What kind of a product do you want to see?(food,toy, book)\nType exit to go to main screen");
                        bool ok = true;
                        var produs = Console.ReadLine();
                        switch (produs)
                        {
                            case "food": SeeItem(costumer, enumtype.aliment, user); break;                             
                            case "toy": SeeItem(costumer, enumtype.jucarii, user); break;
                            case "book": SeeItem(costumer, enumtype.books, user); break;                           
                            default: Console.WriteLine("Invalid input, please try again."); ok = false; break;
                        }
                        if (ok == false)
                            continue;
                        else
                            break;
                    }

                    
                }

            }
        }
    }
}
