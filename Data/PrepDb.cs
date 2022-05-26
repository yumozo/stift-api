using Microsoft.EntityFrameworkCore;
using StiftApi.Models;

namespace StiftApi.Data
{
  public static class PrepDb
  {
    public static void PrepPopulation(IApplicationBuilder app, bool isProd)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
      }
    }

    public static void SeedData(AppDbContext context, bool isProd)
    {
      if (isProd)
      {
        try
        {
          context.Database.Migrate();
        }
        catch (Exception ex)
        {
          Console.WriteLine($"--> Could not run migrations: {ex.Message}");
          throw;
        }
      }

      if (!context.Records.Any())
      {
        Console.WriteLine("--> Seeding data...");
        Console.WriteLine(context.Records);

        context.Records.AddRange(
          new Record { Title = "Name", Text = "This is the first Record", Date = DateTime.Now },
          new Record { Title = "Name", Text = "This is the second Record", Date = DateTime.Now  },
          new Record { Title = "Name", Text = "This is the third Record", Date = DateTime.Now }
        );

        context.SaveChanges();
      }
      else
        Console.WriteLine("--> Data already loaded.");
    }
  }
}