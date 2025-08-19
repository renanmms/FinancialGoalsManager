using FinancialGoalsManager.API.Entities;
using FinancialGoalsManager.API.Persistence;
using FinancialGoalsManager.API.Repositories.Interfaces;

namespace FinancialGoalsManager.API.Repositories
{
    public class FinancialGoalRepository : IFinancialGoalRepository
    {
        private FinancialGoalsDbContext _dbContext;
        public FinancialGoalRepository(FinancialGoalsDbContext dbContext)
        {
            _dbContext = dbContext;    
        }

        public IEnumerable<FinancialGoal> GetAll()
        {
            return _dbContext.FinancialGoals.ToList();
        }

        public int Create(FinancialGoal financialGoal)
        {
            _dbContext.FinancialGoals.Add(financialGoal);
            _dbContext.SaveChanges();

            return financialGoal.Id;
        }

        public FinancialGoal? Get(int id)
        {
            var financialGoal = _dbContext.FinancialGoals.SingleOrDefault(fg => fg.Id == id);

            return financialGoal;
        }

        public int Update(int id, FinancialGoal financialGoal)
        {
            var entity = _dbContext.FinancialGoals.SingleOrDefault(fg => fg.Id == id);
            entity?.Update(financialGoal.Title, financialGoal.TargetQuantity);

            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var financialGoal = _dbContext.FinancialGoals.SingleOrDefault(f => f.Id == id);
            financialGoal?.SetAsDeleted();

            return _dbContext.SaveChanges();
        }
    }
}