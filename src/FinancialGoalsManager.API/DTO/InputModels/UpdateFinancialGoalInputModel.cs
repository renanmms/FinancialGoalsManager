using FinancialGoalsManager.API.Entities;

namespace FinancialGoalsManager.API.DTO.InputModels;

public class UpdateFinancialGoalInputModel
{
    public string? Title { get; set; }
    public decimal TargetQuantity { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}