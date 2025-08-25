namespace FinancialGoalsManager.API.DTO.InputModels;

public class CreateFinancialGoalInputModel
{
    public string? Title { get; set; }
    public decimal TargetQuantity { get; set; }
}