using System.Text.Json.Serialization;
using FinancialGoalsManager.API.Enums;

namespace FinancialGoalsManager.API.Entities
{
    public class Transaction
    {
        public Transaction(int financialGoalId, decimal quantity, TransactionTypeEnum transactionType)
        {
            Quantity = quantity;
            TransactionType = transactionType;
            FinancialGoalId = financialGoalId;
            CreatedAt =  DateTime.UtcNow;
        }

        public int Id { get; set; }
        public int FinancialGoalId { get; set; }
        public decimal Quantity { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}