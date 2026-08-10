using CodeAssessment.Application.Business;
using CodeAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeAssessment.Application.Interface;

public  interface IAppDbContext
{
    DbSet<Planning> Plannings { get; set; } 
    DbSet<Expectation> Expectations { get; set; } 
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}