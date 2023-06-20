using Lottery.DataAccess;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["LotteryDbConnectionString"];
builder.Services.AddDbContext<LotteryDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LotteryDbContext>();

    try
    {
        if (!context.Database.CanConnect()) throw new ConnectionAbortedException("Cannot connect to the database");

        // Migration also creates a DB if needed
        // TODO Check why if a default price tier can be set for Azure SQL to avoid surprises
        context.Database.Migrate();
    }
    catch (Exception e)
    {
        // This is something arbitrary to show an exception being caught,
        // in real life we would log it and/or do something about it
        Console.WriteLine(e.Message);
        Environment.Exit(1);
    }
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