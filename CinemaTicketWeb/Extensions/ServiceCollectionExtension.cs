using CinemaTicket.Core.Contracts;
using CinemaTicket.Core.Services;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.DbInitializer;
using CinemaTicket.Infrastructure.Data.Repositories;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketWeb.Extensions
{
    public static class ServiceCollectionExtension
    {


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddSingleton<IEmailSender, EmailSender>();


            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "395194115367776";
                options.AppSecret = "a9a311c093637d2810184af77745e4e3";
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

    }
}

