using CodeAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAssessment.Persistence.Configurations;

public class PlanningConfiguration : IEntityTypeConfiguration<Planning>
{
    public void Configure(EntityTypeBuilder<Planning> builder)
    {
        builder.HasKey(e => e.PlanningId);
        builder.HasIndex(e => e.RequestCode)
            .IsUnique();
        builder.Property(e => e.CandidateToken);
        builder.Property(e => e.Status);
        builder.Property(e => e.CreatedBy);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.CreatedAtServer);
        builder.Property(e => e.LastUpdatedBy);
        builder.Property(e => e.LastUpdatedAt);
        builder.Property(e => e.LastUpdatedAtServer);
    }
}