using FinancialGoalsManager.API.DTO.InputModels;
using FinancialGoalsManager.API.Entities;
using FinancialGoalsManager.API.Persistence;
using FinancialGoalsManager.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalsManager.API.Repositories
{
    public class FinancialGoalRepository(FinancialGoalsDbContext dbContext) : IFinancialGoalRepository
    {
        private readonly FinancialGoalsDbContext _dbContext = dbContext;

        public IEnumerable<FinancialGoal> GetAll()
        {
            return _dbContext.FinancialGoals
                .Include(f => f.Transactions)
                .ToList();
        }

        public int Create(FinancialGoal financialGoal)
        {
            _dbContext.FinancialGoals.Add(financialGoal);
            _dbContext.SaveChanges();

            return financialGoal.Id;
        }

        public FinancialGoal? Get(int id)
        {
            var financialGoal = _dbContext.FinancialGoals
                .Include(f => f.Transactions)
                .SingleOrDefault(fg => fg.Id == id);

            return financialGoal;
        }

        public int Update(int id, UpdateFinancialGoalInputModel model)
        {
            var financialGoal = _dbContext.FinancialGoals.SingleOrDefault(fg => fg.Id == id);
            financialGoal?.Update(model.Title, model.TargetQuantity);

            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var financialGoal = _dbContext.FinancialGoals.SingleOrDefault(f => f.Id == id);
            financialGoal?.SetAsDeleted();

            return _dbContext.SaveChanges();
        }

        public int CreateTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            
            return _dbContext.SaveChanges();
        }
    }
}