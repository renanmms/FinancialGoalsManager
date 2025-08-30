using FinancialGoalsManager.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialGoalsManager.API.Persistence.Configurations;

public class FinancialGoalEntityTypeConfiguration : IEntityTypeConfiguration<FinancialGoal>
{
    public void Configure(EntityTypeBuilder<FinancialGoal> builder)
    {
        builder.HasKey(f => f.Id);

        builder
            .HasMany(f => f.Transactions)
            .WithOne(t => t.FinancialGoal)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasQueryFilter(f => !f.IsDeleted);
    }
}