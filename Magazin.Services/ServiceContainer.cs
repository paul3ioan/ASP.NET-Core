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
namespace Magazin.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services)
        {

            services.AddDbContext<DepozitContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IGeneralServices, GeneralServices>();
            services.AddScoped<IManager, Manager>();
            services.AddTransient<IEmployer, Employer>();
            services.AddTransient<ICostumer, Costumer>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddScoped<ILogin, Login>();
            return services;                
        }
    }
}
