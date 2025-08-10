using FinancialGoalsManager.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalsManager.API.Persistence
{
    public class FinancialGoalsDbContext : DbContext
    {
        public FinancialGoalsDbContext(DbContextOptions<FinancialGoalsDbContext> options) : base(options)
        {
            
        }

        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}