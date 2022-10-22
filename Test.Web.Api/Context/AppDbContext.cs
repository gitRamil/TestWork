using Microsoft.EntityFrameworkCore;
using Test.Web.Api.Model;

namespace Test.Web.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    #region Конфигурация
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
        #endif
    }
    #endregion


    #region События
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        OnBeforeSaving();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected void OnBeforeSaving()
    {
        foreach (var auditEntity in ChangeTracker.Entries<BaseAuditEntity>())
        {
            switch (auditEntity.State)
            {
                case EntityState.Added:
                    auditEntity.Property(x => x.Modified).IsModified = false;
                    auditEntity.Entity.Created = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    auditEntity.Property(x => x.Created).IsModified = false;
                    auditEntity.Entity.Modified = DateTime.UtcNow;
                    break;
            }
        }
    }
    #endregion

    #region Сущности
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    #endregion
}