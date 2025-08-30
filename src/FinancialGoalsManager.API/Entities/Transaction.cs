using System.Text.Json.Serialization;
using FinancialGoalsManager.API.Enums;
using Microsoft.VisualBasic;

namespace FinancialGoalsManager.API.Entities
{
    // TODO: Change class name
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
        public FinancialGoal FinancialGoal { get; set; }
        public decimal Quantity { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}