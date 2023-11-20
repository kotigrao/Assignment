using Assignment.Infrastructure.Repositories.Attribute;
using Assignment.Infrastructure.Repositories.Category;
using Assignment.Infrastructure.Repositories.ProductRepo;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            return services;
        }
        //public static void ConfigureDependencies(IServiceCollection services)
        //{
        //    // Register your domain services
        //    //services.AddScoped<ICategoryRepository, CategoryRepository>();
        //    //services.AddScoped<IAttributeRepository, AttributeRepository>();

        //    // Register your repositories
        //    services.AddScoped<IProductRepository, ProductRepository>();

        //    // Add other dependencies as needed

        //    // Example: Register your DbContext if using Entity Framework
        //    // services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        //}
    }
}
