using Microsoft.EntityFrameworkCore;
using StiftApi.Models;

namespace StiftApi.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

    public DbSet<Record> Records { get; set; }
  }
}