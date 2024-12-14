using DecoratorPattern.Computers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();


AppleLaptop appleLaptop = new();
appleLaptop.CloseLid();

DellLaptop dell = new();
dell.CloseLid();    

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
