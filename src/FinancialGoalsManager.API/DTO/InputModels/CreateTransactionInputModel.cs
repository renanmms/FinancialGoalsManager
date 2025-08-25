using FinancialGoalsManager.API.Enums;

namespace FinancialGoalsManager.API.DTO.InputModels;

public class CreateTransactionInputModel
{
    public decimal Quantity { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
}