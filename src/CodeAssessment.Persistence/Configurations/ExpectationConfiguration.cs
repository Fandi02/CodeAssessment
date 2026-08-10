using CodeAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAssessment.Persistence.Configurations;

public class ExpectationConfiguration : IEntityTypeConfiguration<Expectation>
{
    public void Configure(EntityTypeBuilder<Expectation> builder)
    {
        builder.HasKey(e => e.PlanningId);
        builder.Property(e => e.Slot);
        builder.Property(e => e.CreatedBy);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.CreatedAtServer);
        builder.Property(e => e.LastUpdatedBy);
        builder.Property(e => e.LastUpdatedAt);
        builder.Property(e => e.LastUpdatedAtServer);
        builder.HasOne(e => e.Planning)
            .WithMany()
            .HasForeignKey(e => e.PlanningId)
            .IsRequired();
    }
}