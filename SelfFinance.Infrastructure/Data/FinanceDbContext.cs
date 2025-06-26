using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfFinance.Domain.Entities;

namespace SelfFinance.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options): IdentityDbContext<ApplicationUser, IdentityRole<int>, int>(options)
{
    public DbSet<TransactionType> TransactionTypes => Set<TransactionType>();
    public DbSet<FinancialOperation> FinancialOperations => Set<FinancialOperation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);        

        modelBuilder.Entity<FinancialOperation>(entity =>
        {
            entity.Property(e => e.Date);

            entity.Property(e => e.Amount)
                  .HasPrecision(18, 2);

            entity.HasOne(e => e.User)
                  .WithMany(u => u.FinancialOperations)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasOne(e => e.User)
                  .WithMany(u => u.TransactionTypes)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}