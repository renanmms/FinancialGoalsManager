using FinancialGoalsManager.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalsManager.API.Persistence
{
    public class FinancialGoalsDbContext : DbContext
    {
        public FinancialGoalsDbContext(DbContextOptions<FinancialGoalsDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialGoal>().HasQueryFilter(f => !f.IsDeleted); 
        }
        
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}