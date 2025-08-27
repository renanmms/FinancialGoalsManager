using FinancialGoalsManager.API.DTO.InputModels;
using FluentValidation;

namespace FinancialGoalsManager.API.Validators;

public class CreateTransactionValidator : AbstractValidator<CreateTransactionInputModel>
{
    public CreateTransactionValidator()
    {
        RuleFor(t => t.Quantity)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
        
    }
}