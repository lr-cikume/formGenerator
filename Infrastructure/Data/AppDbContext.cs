using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ConnectionView> ConnectionViews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ConnectionView>(entity =>
        {
            entity.ToView("vw_db_secrets")
                .HasKey(e => e.SecretId);
            entity.Property(e => e.SecretId).HasColumnName("secret_id");
            entity.Property(e => e.DbName).HasColumnName("db_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });
    }
}