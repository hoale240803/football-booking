using FootballBooking.ActionFilters;
using FootballBooking.Application.Interface;
using FootballBooking.Application.Services;
using FootballBooking.Configurations;
using FootballBooking.Entities;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.Infrastructure.Repository;
using FootballBooking.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.Text;

namespace FootballBooking.Extension
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add Cors service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCORS(this IServiceCollection services)
        {
            services.AddCors(option =>

            option.AddPolicy("CorsPolicy",
                builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())

            );
        }

        /// <summary>
        /// Add IIS
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        /// <summary>
        /// Add log service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            var path = Directory.GetCurrentDirectory();
            LogManager.LoadConfiguration(string.Concat(path, "/nlog.config"));
            //services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Add database
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FootballBookingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FootballBooking"),
                    x => x.MigrationsAssembly("FootballBooking.Migrations")));

            return services;
        }

        /// <summary>
        /// Add Repositories
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IWrapperRepository, WrapperRepository>();
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IStadiumRepository, StadiumRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();


            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IStadiumService, StadiumService>();

            return services;
        }

        /// <summary>
        /// Add Middleware exception
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddlewares>();
        }

        /// <summary>
        /// Add Action Filter
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtTokenValidationParameters.ValidIssuer,
                    ValidAudience = JwtTokenValidationParameters.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenValidationParameters.IssuerSigningKey))
                };
            });

            return services;
        }
    }
}