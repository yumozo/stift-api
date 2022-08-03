using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StiftApi.Models;

namespace StiftApi.Data
{
  // IdentityDbContext stores all the user tables
  public class IdDbContext : IdentityDbContext
  {
    public IdDbContext(DbContextOptions<IdDbContext> opt)
      : base(opt)
    {
      
    }

  }
}