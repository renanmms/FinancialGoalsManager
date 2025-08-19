namespace FinancialGoalsManager.API.Entities
{
    public record FinancialGoal
    {
        public FinancialGoal(string? title, decimal targetQuantity)
        {
            Title = title;
            TargetQuantity = targetQuantity;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal TargetQuantity { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string? title, decimal targetQuantity)
        {
            Title = title;
            TargetQuantity = targetQuantity;
        }
        
        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}