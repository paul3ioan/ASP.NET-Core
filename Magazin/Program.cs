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
    class Program
    {
      
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
            .AddDbContext<DepozitContext>()
            .AddTransient(typeof(IRepository<>), typeof(Repository<>))
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient<IGeneralServices, GeneralServices>()
            .AddScoped<IManager, Manager>()
            .AddScoped<IEmployer, Employer>()
            .AddScoped<ICostumer, Costumer>()
            .AddScoped<IProductServices, ProductServices>()
            .AddTransient<IUserServices, UserServices>()
            .AddScoped<ILogin, Login>()
            .BuildServiceProvider();
            IProductServices productServices;
            using(var scope =serviceProvider.CreateScope())
            {
                productServices = scope.ServiceProvider.GetService<IProductServices>();
            }
            productServices.RemoveProduct(5, "Radu");
            //using (var scope = serviceProvider.CreateScope())
          //  {
              //  Interface.Interfacee(scope);
           // }
        }       
    }
}
