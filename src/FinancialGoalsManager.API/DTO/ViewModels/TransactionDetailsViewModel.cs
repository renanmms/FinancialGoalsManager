using FinancialGoalsManager.API.Enums;

namespace FinancialGoalsManager.API.DTO.ViewModels;

public record TransactionDetailsViewModel(
    int FinancialGoalId,
    decimal Quantity,
    TransactionTypeEnum TransactionType,
    DateTime CreatedAt);