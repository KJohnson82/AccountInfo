using AccountInfo.Data.Data;
using AccountInfo.ServiceDefaults;
using AccountInfo.Shared.DTOs;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddNpgsqlDbContext<AppInfoDbContext>(
    connectionName: "appinfodb");


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("ATTEMPTING TO RUN MIGRATIONS...");
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppInfoDbContext>();
    await db.Database.MigrateAsync();
    Console.WriteLine("MIGRATIONS COMPLETED!");
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api/locations", async (AppInfoDbContext db) =>
{
    var locations = await db.Locations
        .Include(l => l.Loctype)
        .Where(l => l.Active == true)
        .ToListAsync();
    return Results.Ok(locations);
});

app.MapGet("/api/loctypes", async (AppInfoDbContext db) =>
{
    //var loctypes = await db.Loctypes.ToListAsync();
    var loctypes = LoctypeDto.GetLoctype();
    return Results.Ok(loctypes);
});

app.MapDefaultEndpoints();

app.Run();

