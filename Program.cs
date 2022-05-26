using Microsoft.EntityFrameworkCore;
using StiftApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsProduction())
{
  Console.WriteLine("--> Connecting to SqlServer BD.");
  builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("db_connection_string")));
  Console.WriteLine("--> Connected to " + builder.Configuration.GetConnectionString("db_connection_string"));
}   
else
{
  Console.WriteLine("--> Using InMemory DB");
  builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMemory"));
}

// Added stuff
builder.Services.AddScoped<IStiftRepo, StiftRepo>();

builder.Services.AddControllers();

// Automapper resolver
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();
