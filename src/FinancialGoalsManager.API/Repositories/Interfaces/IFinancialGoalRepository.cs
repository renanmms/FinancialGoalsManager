using FinancialGoalsManager.API.DTO.InputModels;
using FinancialGoalsManager.API.Entities;

namespace FinancialGoalsManager.API.Repositories.Interfaces
{
    public interface IFinancialGoalRepository
    {
        FinancialGoal? Get(int id);
        IEnumerable<FinancialGoal> GetAll();
        int Create(FinancialGoal financialGoal);
        int Update(int id, UpdateFinancialGoalInputModel model);
        int Delete(int id);
        int CreateTransaction(Transaction transaction);
    }
}