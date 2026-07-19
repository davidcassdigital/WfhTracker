using WfhTracker.Api.Repositories;

namespace WfhTracker.Api.Extensions
{
    public static class MapEndpointsExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            MapHealthEndpoints(app);
            MapEntriesEndpoints(app);

            return app;
        }

        private static WebApplication MapEntriesEndpoints(WebApplication app)
        {
            app.MapGet("/api/entries",
                async (IEntryRepository repository) =>
                {
                    return Results.Ok(await repository.GetAllAsync());
                }
            );

            return app;
        }

        private static WebApplication MapHealthEndpoints(WebApplication app)
        {
            app.MapGet("/api/health", () =>
            {
                return Results.Ok(new
                {
                    Status = "Healthy",
                    Time = DateTime.UtcNow
                });
            });

            return app;
        }
    }
}