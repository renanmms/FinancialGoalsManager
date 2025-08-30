using FinancialGoalsManager.API.Entities;
using FinancialGoalsManager.API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalsManager.API.Persistence
{
    public class FinancialGoalsDbContext : DbContext
    {
        public FinancialGoalsDbContext(DbContextOptions<FinancialGoalsDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialGoalEntityTypeConfiguration).Assembly);
        }
        
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}