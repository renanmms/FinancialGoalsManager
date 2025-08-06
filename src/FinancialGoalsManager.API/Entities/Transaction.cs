using FinancialGoalsManager.API.Enums;

namespace FinancialGoalsManager.API.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}