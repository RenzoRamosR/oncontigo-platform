using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using oncontigo_platform.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using oncontigo_platform.Shared.Domain.Repositories;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.HealthTracking.Infrastructure;
using oncontigo_platform.HealthTracking.Domain.Services;
using oncontigo_platform.HealthTracking.Application.Internal.CommandServices;
using oncontigo_platform.HealthTracking.Application.Internal.QueryServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString == null) return;
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(o => o.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMedicineRepository,MedicineRepository>();
builder.Services.AddScoped<IMedicineCommandService,MedicineCommandService>();
builder.Services.AddScoped<IMedicineQueryService, MedicineQueryService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
