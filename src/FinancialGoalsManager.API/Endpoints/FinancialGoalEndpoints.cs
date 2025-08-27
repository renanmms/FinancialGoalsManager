using FinancialGoalsManager.API.DTO.InputModels;
using FinancialGoalsManager.API.Entities;
using FinancialGoalsManager.API.Mappers;
using FinancialGoalsManager.API.Repositories.Interfaces;
using FinancialGoalsManager.API.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalsManager.API.Endpoints
{
    public static class FinancialGoalEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/financialgoal", (IFinancialGoalRepository repository) =>
            { 
                var financialGoals = repository.GetAll();

                var mapper = new FinancialGoalMapper();
                var financialGoalsDto = mapper.FinancialGoalToListDto(financialGoals);

                return Results.Ok(financialGoalsDto);
            })
            .WithName("GetAll")
            .WithOpenApi();
            
            app.MapGet("/financialgoal/{id:int}", (int id, IFinancialGoalRepository repository) =>
            {
                var financialGoal = repository.Get(id);
                if (financialGoal is null)
                {
                    return Results.NotFound();
                }
                
                var mapper = new FinancialGoalMapper();
                var model = mapper.FinancialGoalToDto(financialGoal);
                
                return Results.Ok(model);
            })
            .WithName("GetById")
            .WithOpenApi();

            app.MapPost("/financialgoal", ([FromBody]CreateFinancialGoalInputModel model, IFinancialGoalRepository repository) => 
            { 
                var financialGoal = new FinancialGoal(model.Title, model.TargetQuantity);
                var id = repository.Create(financialGoal);
                
                return Results.Created("/financialgoal/{id}", new { id });
            })
            .WithName("Create")
            .WithOpenApi();

            app.MapPut("/financialgoal/{id:int}", (int id, [FromBody]UpdateFinancialGoalInputModel model,  IFinancialGoalRepository repository) =>
            {
                repository.Update(id, model);
                
                return Results.NoContent();
            })
            .WithName("Update")
            .WithOpenApi();

            app.MapDelete("/financialgoal/{id:int}", (int id, IFinancialGoalRepository repository) =>
            {       
                repository.Delete(id);
                
                return Results.Ok("Successfully deleted!");
            });

            app.MapPost("/financialgoal/{id:int}/transaction", (int id, [FromBody]CreateTransactionInputModel model, IFinancialGoalRepository repository) =>
            {
                var validator = new CreateTransactionValidator();
                
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    return Results.BadRequest(result.Errors);
                }
                
                var transaction = new Transaction(id, model.Quantity, model.TransactionType);
                repository.CreateTransaction(transaction);

                return Results.NoContent();
            });
        }
    }
}