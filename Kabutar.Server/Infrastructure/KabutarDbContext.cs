using Kabutar.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Kabutar.Server.Infrastructure;

public class KabutarDbContext : DbContext
{
    public KabutarDbContext(DbContextOptions<KabutarDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
     
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    

    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Topic> Topics { get; set; }
}
