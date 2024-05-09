using CarRenting.BusinessLogic;
using CarRenting.BusinessLogic.Abstractions;
using CarRenting.DataAccess;
using CarRenting.DataAccess.Abstractions;
using CarRenting.Models.Entities;
using CarRenting.Models.SettingModels;
using Microsoft.AspNetCore.Identity;

namespace CarRenting.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureServiceFactory(this IServiceCollection services) =>
            services.AddScoped<IServiceFactory, ServiceFactory>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddSqlServer<CarRentingDbContext>(
                    configuration.GetConnectionString("CarRentingDbContextConnection"))
                .AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CarRentingDbContext>();

        public static void RegisterMapsterConfiguration(this IServiceCollection _)
        {
            // Company
            //TypeAdapterConfig<Company, CompanyDto>
            //    .NewConfig()
            //    .Map(dest => dest.FullAddress, src => string.Join(' ', src.Address, src.Country));

            //TypeAdapterConfig<CompanyUpdateDto, Company>
            //    .NewConfig()
            //    .IgnoreNullValues(true);
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
                {
                    o.Password.RequireDigit = true;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 10;
                    o.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<CarRentingDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddFluentEmail(this IServiceCollection services, IConfiguration
            configuration)
        {
            var emailConfiguration = new EmailConfiguration();
            services.Configure<EmailConfiguration>(configuration.GetSection(emailConfiguration.Section));

            var emailSettings = configuration.GetSection(emailConfiguration.Section);

            services
                .AddFluentEmail(emailSettings["DefaultFromEmail"])
                .AddSmtpSender(
                    emailSettings["SmtpHost"],
                    emailSettings.GetValue<int>("Port"),
                    emailSettings["BusinessEmail"],
                    emailSettings["Password"])
                .AddRazorRenderer();
        }
    }
}