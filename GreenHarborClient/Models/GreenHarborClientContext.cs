using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenHarborClient.Models
{
  public class GreenHarborClientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Compost> Composts { get; set; }
    public GreenHarborClientContext(DbContextOptions options) : base(options) {}
  }
}