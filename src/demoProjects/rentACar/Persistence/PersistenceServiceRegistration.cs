using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Context;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(@"Server=DESKTOP-R8212T7;Database=RentACarDb;UID=msural;PWD=sural6177;"));
            //services.AddDbContext<BaseDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("RentACarCampConnectionString")));

            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
