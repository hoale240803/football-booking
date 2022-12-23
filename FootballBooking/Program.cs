using FootballBooking.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureRepository();
builder.Services.AddAppServices();
builder.Services.ConfigureActionFilter();
builder.Services.AddAutoMapper();

builder.Services.AddControllers();


    using IHost host = Host.CreateDefaultBuilder(args)
                            .ConfigureHostConfiguration(configHost =>
                            {
                                configHost.SetBasePath(Directory.GetCurrentDirectory());
                                configHost.AddJsonFile("appsettings.json", optional: true);
                                configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                                configHost.AddCommandLine(args);
                            }).Build();
       

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO: configure Exception service
//var logger = app.Services.GetRequiredService<ILoggerManager>();
//app.ConfigureExceptionHandler(logger);
app.UseAuthorization();

app.MapControllers();

app.ConfigureCustomExceptionMiddleware();

app.Run();