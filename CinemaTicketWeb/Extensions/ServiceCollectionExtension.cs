using System.Globalization;
using CinemaTicket.Core.Constants;
using CinemaTicket.Core.Contracts;
using CinemaTicket.Core.Services;
using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Data.DbInitializer;
using CinemaTicket.Infrastructure.Data.Repositories;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Utility;
using CinemaTicketWeb.ModelBinders;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddMvcOptions(options =>
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(FormatingConstant.NormalDateFormat));
                options.ModelBinderProviders.Insert(2, new DoubleModelBinderProvider());
            })
                .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix);

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedLanguages = new CultureInfo[]
                {
                    new CultureInfo("bg"),
                    new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture("bg");
                options.SupportedCultures = supportedLanguages;
                options.SupportedUICultures = supportedLanguages;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IHomeService, HomeService>();

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

