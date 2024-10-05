using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace parcial.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<parcial.Models.RegistroRemesa> DataRegistroRemesa { get; set; }
    public DbSet<parcial.Models.HistorialConversion> HistorialConversiones { get; set; }
}
