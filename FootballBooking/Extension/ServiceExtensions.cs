using FootballBooking.ActionFilters;
using FootballBooking.Application.Interface;
using FootballBooking.Application.Services;
using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Base;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.Infrastructure.Repository;
using FootballBooking.Middlewares;
using Microsoft.EntityFrameworkCore;
using NLog;

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
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IStadiumRepository, StadiumRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();


            //var provider = services.BuildServiceProvider();
            //BaseRepository<Stadium> baseRepo = provider.GetService<BaseRepository<Stadium>>();   
            return services;
       
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
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
    }
}