using WfhTracker.Shared.Models;

namespace WfhTracker.Api.Extensions
{
    public static class MapEndpointsExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            MapHealthEndpoints(app);
            MapWorkFromHomeEntriesEndpoints(app);

            return app;
        }

        private static WebApplication MapWorkFromHomeEntriesEndpoints(WebApplication app)
        {
            app.MapGet("/api/workfromhomeentries", () =>
            {
                return Results.Ok(
                new List<WorkFromHomeEntry>
                {
                    new() {
                        Id = Guid.NewGuid(),
                        Date = DateOnly.FromDateTime(DateTime.UtcNow),
                        HoursWorked = 8,
                        Notes = "Worked on project X"
                    },
                    new() {
                        Id = Guid.NewGuid(),
                        Date = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)),
                        HoursWorked = 6,
                        Notes = "Worked on project Y"
                    }
                });
            });

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