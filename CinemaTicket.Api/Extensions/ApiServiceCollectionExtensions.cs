using CinemaTicket.Core.Contracts;
using CinemaTicket.Core.Services;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.DbInitializer;
using CinemaTicket.Infrastructure.Data.Repositories;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IHomeService, HomeService>();

            services.AddSingleton<IEmailSender, EmailSender>();




            return services;
        }
        public static IServiceCollection AddApiDbContexts(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            return services;
        }


    }
}
