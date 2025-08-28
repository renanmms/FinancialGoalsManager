using FinancialGoalsManager.API.DTO.InputModels;
using FluentValidation;

namespace FinancialGoalsManager.API.Validators;

public class CreateFinancialGoalValidator : AbstractValidator<CreateFinancialGoalInputModel>
{
    public CreateFinancialGoalValidator()
    {
        RuleFor(f => f.Title)
            .NotNull()
            .NotEmpty();
        
        RuleFor(f => f.TargetQuantity)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage($"The target quantity must be greater than zero.");
    }
}