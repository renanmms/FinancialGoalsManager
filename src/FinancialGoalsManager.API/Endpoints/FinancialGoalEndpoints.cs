using FinancialGoalsManager.API.DTO.InputModels;
using FinancialGoalsManager.API.DTO.ViewModels;
using FinancialGoalsManager.API.Entities;
using FinancialGoalsManager.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalsManager.API.Endpoints
{
    public static class FinancialGoalEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/financialgoal", (IFinancialGoalRepository repository) =>
            {
                // TODO: Use a DTO for list
                var financialGoals = repository.GetAll();

                return Results.Ok(financialGoals);
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
                
                var model = new FinancialGoalDetailsViewModel(
                    financialGoal.Id,
                    financialGoal.Title,
                    financialGoal.TargetQuantity,
                    financialGoal.CreatedAt);
                
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
                var transaction = new Transaction(id, model.Quantity, model.TransactionType);
                repository.CreateTransaction(transaction);

                return Results.NoContent();
            });
        }
    }
}