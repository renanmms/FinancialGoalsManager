namespace FinancialGoalsManager.API.DTO.ViewModels;

public record FinancialGoalDetailsViewModel(
    int Id,
    string? Title,
    decimal TargetQuantity,
    DateTime CreatedAt,
    IEnumerable<TransactionDetailsViewModel> Transactions);