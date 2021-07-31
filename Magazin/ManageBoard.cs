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

namespace Magazin
{
    public class ManageBoard
    {
        public static void ManagerBoard(IServiceScope scope,string username)
        {
            IManager manager;
            manager =scope.ServiceProvider.GetService<IManager>();
            while (true)
            {
                Console.WriteLine($"Press[1] add employer \nPress[2] to exit\nPress[3] to fire someone\nPress[4] to change price of a product\nPress[5] to change thing about your account");
                var input = Console.ReadLine();
                int task = 0;
                try
                {
                    task = Int32.Parse(input);
                }
                catch
                {
                    Console.WriteLine($"Input is wrong. Try something else.");
                    continue;
                }
                if(task == 5)
                {

                }
                if (task == 2)
                    break;
               // if (task == 1)
            //    {               
              //          manager.AddEmployer();
                //        Console.WriteLine($"User Created!\n");
                //}

                if (task == 3)
                {
                        var allEmployer = manager.AllEmployer();
                        foreach (var item in allEmployer)
                        {
                            Console.WriteLine($"{item.UserName} - {item.FirstName} - {item.LastName}");
                        }
                        Console.WriteLine($"Who do you want to fire? Write his username: ");
                        while (true)
                        {
                            var name = Console.ReadLine();
                            if (name == null)
                            {
                                Console.WriteLine($"Please write a corect username!");
                                continue;
                            }
                            else
                            {
                                manager.RemoveUser(name);
                                break;
                            }
                        }
                    
                }
                if (task == 4)
                {
                    Console.WriteLine($"Choose a product to change");
                    var name = Console.ReadLine();
                    Console.WriteLine($"If you want to rise a price write add otherwise write substract if you want to lower it s price(add or substract):");
                    while (true)
                    {

                        var input1 = Console.ReadLine();
                        bool flag = false;
                        if (input1 == "add") flag = true;
                        else
                            if (input1 == "substract") flag = false;
                        else
                        {
                            Console.WriteLine($"Input invalid!");
                            continue;
                        }
                        Console.WriteLine($"what is amount you want the produces to changes?:");

                        int amount;
                        while (true)
                        {
                            input1 = Console.ReadLine();
                            try
                            {
                                amount = Int32.Parse(input1);
                                if (amount < 1)
                                {
                                    Console.WriteLine($"Wrong amount! Try to write a number maybe");
                                    continue;
                                }
                                break;
                            }
                            catch
                            {
                                Console.WriteLine($"Wrong amount! Try to write a number maybe");
                            }
                        }
                        if (flag == true)
                            manager.ChangePrice(name, amount);
                        else
                            manager.ChangePrice(name, -amount);
                        break;
                    
                    }
                }
            }
        }
    }
}
