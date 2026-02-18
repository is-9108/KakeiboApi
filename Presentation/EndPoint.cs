namespace Kakeibo.Presentation
{
    public class EndPoint
    {
        public static void MapEndPoints(WebApplication app)
        {
            app.MapGet("/", () => "Hello World!").WithName("Test").WithOpenApi();
        }
    }
}
