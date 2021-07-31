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
using System.Runtime.InteropServices.ComTypes;

namespace Magazin
{
    public class Interface
    {
         public  void Interfacee(IProductServices repository )
        {
            //EmployerBoard.EmployerBoardd(repository);
            /*while (true)
            {
                Console.WriteLine($" Press [1] to see products \n Press [2] to Login \n Press[3] to Authentificate\n Press[4] to exit \n");
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
                if (task < 1 || task > 4)
                {
                    Console.WriteLine($"Input is wrong. Try something else.");
                    continue;
                }
                if (task == 1)
                {
                    IUserServices userServices; 
                        userServices = scope.ServiceProvider.GetService<IUserServices>();
                    
                        bool ok = true;
                        while (ok == true)
                        {
                            Console.WriteLine($"What kind of a product do you want to see?(food,toy, book)\nType exit to go to main screen");
                            var produs = Console.ReadLine();
                            switch (produs)
                            {
                                case "food":
                                    ShowProducts(userServices, enumtype.aliment);
                                    break;
                                case "toy":
                                ShowProducts(userServices, enumtype.jucarii);
                                break;
                            case "book":
                                ShowProducts(userServices, enumtype.books);
                                break;
                            case "exit": ok = false; break;
                                default: Console.WriteLine("Invalid input, please try again."); break;
                            }
                        }
                    
                    
                }
                if (task == 2)
                {
                    ILogin login;
                        login = scope.ServiceProvider.GetService<ILogin>();
                    while (login.Instancy() == true)
                    {

                        /*    Console.WriteLine($"Please enter Username:");
                            var input1 = Console.ReadLine();
                            Console.WriteLine($"Please enter Password:");
                            var input2 = Console.ReadLine();
                            var user = login.Authentification(input1, input2);
                            if (rauser != rank.wrong)
                            {
                                if (rank_user == rank.manager)
                                   ManageBoard.ManagerBoard(scope, input1);
                                else
                                    if (rank_user == rank.employer) 
                                    EmployerBoard.EmployerBoardd(scope, input1);
                                else
                                    CostumerBoard.CostumerBoardd(scope,input1); 
                                break;
                            }
                            else
                                Console.WriteLine($"Task failed succesfully\nTry again");
                        }
                        if (login.Instancy() == false)
                            Console.WriteLine($"You failed to login 3 times in a row ");

                    
    
                    }
                }
                if(task == 3)
                {
                    ICostumer costumer;
                   
                    
                        costumer = scope.ServiceProvider.GetService<ICostumer>();
                        costumer.AddCostumer();
                   
                }
                if (task == 4)
                    break;
            }
            Console.WriteLine($"Thank you for visiting our site!");
        */}
        private static void ShowProducts(IUserServices userServices,enumtype type)
        {
            Console.WriteLine($" This is the first page of food\n If you want to get to the previous page press [prev]\n If you want to get to the next page press [next]\n Press [exit] to exit");
            int Instance = 0;
            bool ok = true;
            var list = new List<ProductDto>();
            userServices.ShowProducts(type, Instance);
            while (ok == true)
            {     
                         
                var produs = Console.ReadLine();                
                switch (produs)
                {
                    case "exit":
                        return;
                        
                    case "next":
                        list = userServices.ShowProducts(enumtype.aliment, Instance = Instance + 30);
                        if (list == null) Instance -= 30;
                        break;

                    case "prev":
                        list = userServices.ShowProducts(enumtype.aliment, Instance = Instance - 30);
                        if (list == null) Instance += 30;
                        break;
                    default:
                        {
                            Console.WriteLine($" Invalid input, try again ");
                            break;
                        }
                }
            }
            
        }
    }
}
