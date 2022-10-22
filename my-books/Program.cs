using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using my_books.Data;
using my_books.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//Configure DBContext with SQL
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnectionString")));

//Configure the Services
builder.Services.AddTransient<BooksService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//DBSeed
AppDbInitializer.Seed(app);

app.Run();
