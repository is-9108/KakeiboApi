using Kakeibo.Application;
using Kakeibo.Application.DTO;

namespace Kakeibo.Presentation
{
    public class EndPoint
    {
        public static void MapEndPoints(WebApplication app)
        {
            app.MapGet("/", () => "Hello World!").WithName("Test").WithOpenApi();
            app.MapGet("/api/categories", async (Category category) =>
            {
                var categories = await category.GetAllCategoriesAsync();
                return Results.Ok(categories);
            })
            .WithName("GetAllCategories")
            .WithOpenApi();

            app.MapPost("/api/registerTransactions", async (Transaction transaction, RegisterTransactionRequest request) =>
            {
                await transaction.AddTransactionAsync(request);
                return Results.Ok();
            })
            .WithName("RegisterTransaction")
            .WithOpenApi();

            app.MapGet("/api/transactions", async (Transaction transaction) =>
            {
                var transactions = await transaction.GetAllTransactionsAsync();
                return Results.Ok(transactions);
            })
            .WithName("GetAllTransactions")
            .WithOpenApi();

            app.MapGet("/api/transactions/{id}", async (Transaction transaction, int id) =>
            {
                var result = await transaction.GetTransactionById(id);
                if (result == null)
                    return Results.NotFound();
                return Results.Ok(result);
            })
            .WithName("GetTransactionById")
            .WithOpenApi();

            app.MapPut("/api/updateTransactions", async (Transaction transaction, UpdateTransactionRequest request) =>
            {
                await transaction.UpdateTransactionAsync(request);
                return Results.Ok();
            })
            .WithName("UpdateTransaction")
            .WithOpenApi();

            app.MapDelete("/api/transactions/{id}", async (Transaction transaction, int id) =>
            {
                await transaction.DeleteTransactionAsync(id);
                return Results.Ok();
            })
            .WithName("DeleteTransaction")
            .WithOpenApi();
        }
    }
}
