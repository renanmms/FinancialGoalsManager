using FinancialGoalsManager.API.Entities;

namespace FinancialGoalsManager.API.Repositories
{
    public interface IFinancialGoalRepository
    {
        FinancialGoal? Get(int id);
        int Create(FinancialGoal financialGoal);
        int Update(int id, FinancialGoal financialGoal);
    }
}