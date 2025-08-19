using FinancialGoalsManager.API.Entities;

namespace FinancialGoalsManager.API.Repositories.Interfaces
{
    public interface IFinancialGoalRepository
    {
        FinancialGoal? Get(int id);
        IEnumerable<FinancialGoal> GetAll();
        int Create(FinancialGoal financialGoal);
        int Update(int id, FinancialGoal financialGoal);
        int Delete(int id);
    }
}