namespace FinancialGoalsManager.API.Entities
{
    public class FinancialGoal
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal TargetQuantity { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}