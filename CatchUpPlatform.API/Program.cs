using CatchUpPlatform.API.News.Application.Internal.CommandServices;
using CatchUpPlatform.API.News.Application.Internal.QueryServices;
using CatchUpPlatform.API.News.Domain.Repositories;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.News.Infrastructure.Persistence.EFC.Repositories;
using CatchUpPlatform.API.Shared.Domain.Repositories;
using CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => 
    options.Conventions.Add(new KebabCaseRouteNamingConvention()));

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (connectionString is null)
            throw new Exception("Connection string is null");
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });

// Configure Dependency Injection for Application Services

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration
builder.Services.AddScoped<IFavoriteSourceRepository,       FavoriteSourceRepository>();
builder.Services.AddScoped<IFavoriteSourceCommandService,   FavoriteSourceCommandService>();
builder.Services.AddScoped<IFavoriteSourceQueryService,     FavoriteSourceQueryService>();

var app = builder.Build();

// Verify Database Objects are Created 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();