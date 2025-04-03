using Domain.Entities.DataContext;
using Domain.Entities.DataContext.SpResults;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataDbContext : DbContext, IDataConnection
{
    private readonly string _connectionString;
    
    public DataDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    #region Form tables

    public DbSet<InputType> InputTypes { get; set; }
    public DbSet<FormField> FormFields { get; set; }
    public DbSet<InputField> InputFields { get; set; }
    public DbSet<FormDesign> FormDesigns { get; set; }

    #endregion

    #region Form save table

    public DbSet<ContactData> ContactData { get; set; }

    #endregion

    #region StoredProcedure tables

    public DbSet<MailSpResult> MailSpResults { get; set; }

    public DbSet<ReferredSpResult> ReferredSpResults { get; set; }

    public DbSet<SalesPersonSpResult> SalesPersonSpResults { get; set; }

    public DbSet<NextActionSpResult> NextActionSpResults { get; set; }

    public DbSet<CustomerTypeSpResult> CustomerTypeSpResults { get; set; }

    #endregion


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FormDesign>(entity => {
            entity.HasKey(e => e.Id);
            entity.HasMany(e => e.InputFields)
                .WithOne(eo => eo.FormDesign)
                .HasForeignKey(eo => eo.FormDesignId);
            entity.ToTable("form_design", "frm");
        });

        modelBuilder.Entity<InputField>(entity => {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.InputType)
                .WithMany(eo => eo.InputFields)
                .HasForeignKey(eo => eo.InputTypeId);
            entity.ToTable("input_field", "frm");
        });

        modelBuilder.Entity<InputType>(entity => {
            entity.HasKey(e => e.Id);
            entity.ToTable("input_type", "frm");
        });

        modelBuilder.Entity<FormField>(entity => {
            entity.HasKey(e => e.Id);
            entity.ToTable("fields", "frm");
        });

        modelBuilder.Entity<ContactData>(entity =>
        {
            entity.ToTable("prospect", tb => tb.HasTrigger("InsertProspectCostcenter"));
            entity.HasKey(e => e.Pro_id);
        });

        modelBuilder.Entity<MailSpResult>().HasNoKey().ToView(null);
        modelBuilder.Entity<ReferredSpResult>().HasNoKey().ToView(null);
        modelBuilder.Entity<SalesPersonSpResult>().HasNoKey().ToView(null);
        modelBuilder.Entity<NextActionSpResult>().HasNoKey().ToView(null);
        modelBuilder.Entity<CustomerTypeSpResult>().HasNoKey().ToView(null);
        modelBuilder.Entity<LstActnSpResult>().HasNoKey().ToView(null);
    }
}
