namespace FinancialGoalsManager.API.DTO.ViewModels;

public record GetFinancialGoalsViewModel(
    int Id,
    string? Title,
    decimal TargetQuantity,
    DateTime CreatedAt);