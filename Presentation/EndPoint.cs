using Kakeibo.Application;

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
        }
    }
}
