using Domain.Entities;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class EleCrmContext : DbContext
{
    public DbSet<Request> Requests { get; set; } = null!; 
    
    public EleCrmContext(DbContextOptions<EleCrmContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            new ConfigurationBuilder()
                .AddJsonFile("appsettings." +
                             $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json")
                .Build().GetSection("ConnectionStrings")["ConnectionString"]
            ?? throw new Exception("Connection string is not found."));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RequestConfiguration());
    }
}