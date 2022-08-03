using Microsoft.AspNetCore.Identity;
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
  // AddIdentity registers the services
builder.Services.AddIdentity<IdentityUser, IdentityRole>(confing => {
  confing.Password.RequiredLength = 4; 
  confing.Password.RequireDigit = false; 
  confing.Password.RequireNonAlphanumeric = false; 
  confing.Password.RequireUppercase= false; 
})
  .AddEntityFrameworkStores<AppDbContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
  options.Cookie.Name = "I LOVE COOKIIIIIIIIIIIIIIIIIIIES";
  options.LoginPath = "home/login";
});

builder.Services.AddScoped<IStiftRepo, StiftRepo>();
//

builder.Services.AddControllersWithViews();

// Automapper resolver
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();
