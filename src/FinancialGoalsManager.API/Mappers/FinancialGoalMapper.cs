using FinancialGoalsManager.API.DTO.ViewModels;
using FinancialGoalsManager.API.Entities;
using Riok.Mapperly.Abstractions;

namespace FinancialGoalsManager.API.Mappers;

[Mapper]
public partial class FinancialGoalMapper
{
    public partial FinancialGoalDetailsViewModel FinancialGoalToDto(FinancialGoal financialGoal);
}