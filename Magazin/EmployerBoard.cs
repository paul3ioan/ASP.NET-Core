using Magazin.Services.Product;
using Magazin.Services.Users.TypeOfUsers;
using MagazinData;
using MagazinData.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin
{
    public class EmployerBoard
    {
        private readonly IEmployer employer;
        public EmployerBoard(IEmployer employer)
        {
            this.employer = employer;
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
                    if (input < 1 || input > 3)
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
        public  void EmployerBoardd(IProductServices  repository)
        {
            string name = "Radu";
            
            repository.RemoveProduct( 5,name);
       /*     IEmployer employer;
            employer = scope.ServiceProvider.GetService<IEmployer>();
            Console.WriteLine($"Press[1] to add a product\nPress[2] to remove a product\nPress[3] to exit");
            int task = CheckInput();
            if (task == 1)
            {

                while (true)
                {
                    Console.WriteLine($"What kind of a product do you want to see?(food,toy, book)\nType exit to go to main screen");
                    bool ok = true;
                    var produs = Console.ReadLine();
                    switch (produs)
                    {
                        case "food": employer.AddProduct(enumtype.aliment,user); break;
                        case "toy": employer.AddProduct(enumtype.jucarii, user); break;
                        case "book": employer.AddProduct(enumtype.books, user); break;
                        default: Console.WriteLine("Invalid input, please try again."); ok = false; break;
                    }
                    if (ok == false)
                        continue;
                    else
                        break;
                }
            }
            if(task == 2)
            {
                Console.WriteLine($"Id-ul produsului care urmeaza a fi sters");
                var id = Int32.Parse(Console.ReadLine());
                employer.RemoveProduct(user, id);
            }
            if (task == 3)
                return;
        */}
    }
}
