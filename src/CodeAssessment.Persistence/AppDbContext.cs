using CodeAssessment.Application.Business;
using CodeAssessment.Application.Interface;
using CodeAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeAssessment.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Planning> Plannings { get; set; }
    public DbSet<Expectation> Expectations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
