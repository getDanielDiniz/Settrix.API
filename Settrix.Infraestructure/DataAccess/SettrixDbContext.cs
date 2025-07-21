using Microsoft.EntityFrameworkCore;
using Settrix.Domain.Entities;

namespace Settrix.Infraestructure.DataAccess;

public class SettrixDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public SettrixDbContext(DbContextOptions<SettrixDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureUserTable(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureUserTable(ModelBuilder modelBuilder)
    {
        //Users -> Company n:1 relationship
        modelBuilder.Entity<User>().ToTable("Users")
            .HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId)
            .IsRequired(true);

        modelBuilder.Entity<User>()
            .HasData(new User()
            {
                Id = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1,
                SecurityId = Guid.NewGuid(),
                IsActive = true,
                CompanyId = 5,
                Name = "Bill Gatos", 
            });
        
        //Users -> User 1:n relationship
        modelBuilder.Entity<User>()
            .HasOne(u => u.CreatedByUser)
            .WithMany()
            .HasForeignKey(u => u.CreatedBy)
            .IsRequired(true);
        
        //Users -> User 1:n relationship
        modelBuilder.Entity<User>()
            .HasOne(u => u.UpdatedByUser)
            .WithMany()
            .HasForeignKey(u => u.UpdatedBy)
            .IsRequired(false);
        
        //Companies -> User 1:n relationship
        modelBuilder.Entity<Company>()
            .HasOne(c => c.CreatedByUser)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .IsRequired(true);
    }
}