using EasyWeb.TicketsMicroservice.Models.Context;
using EasyWeb.TicketsMicroservice.Models.UnitsOfWork;
using EasyWeb.TicketsMicroservice.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RequestFiltering.Services;
using Serilog;
using Serilog.Events;
using System.Globalization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

var contact = new OpenApiContact()
{
    Name = "TicketManagement",
    Email = "software@iotsl.es",
    Url = new Uri("http://www.iotsl.es")
};

var license = new OpenApiLicense()
{
    Name = "Free License",
    Url = new Uri("http://www.iotsl.es")
};

var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "Minimal API - JWT Authentication with Swagger demo",
    Description = "Implementing JWT Authentication in Minimal API",
    TermsOfService = new Uri("http://www.example.com"),
    Contact = contact,
    License = license
};

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});

ILoggerFactory loggerFactory = new LoggerFactory();

loggerFactory.AddSerilog(new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.File(
                                "C:/ProyectoIoT/Back/Logs/log-{Date}.txt",
                                rollingInterval: RollingInterval.Day,
                                restrictedToMinimumLevel: LogEventLevel.Information
                            ).CreateLogger());

builder.Services.AddSingleton(typeof(ILoggerFactory), loggerFactory);
builder.Services.AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger), loggerFactory.CreateLogger("EatEazy_RestaurantsMicroservice"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TicketsDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<JuaniteUnitOfWork>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Translations");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-ES")
                };

    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
    {
        return await Task.FromResult(new ProviderCultureResult("en"));
    }));
});

//A�adimos servicio de filtro
builder.Services.AddTransient<IBlockingService, BlockingService>();
builder.Services.AddScoped<ITicketsService, TicketsService>();
builder.Services.AddScoped<IMessagesService, MessagesService>();
builder.Services.AddScoped<IAttachmentsService, AttachmentsService>();


//A�adimos los servicios necesarios

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<TicketsDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
