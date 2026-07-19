using Microsoft.AspNetCore.Mvc;
using WfhTracker.Api.Repositories;
using WfhTracker.Shared.Models;

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
            // Could be improved by moving out to a separate class for each endpoint.
            app.MapGet("/api/entries",
                async ([FromServices] IEntryRepository repository) =>
                {
                    return Results.Ok(await repository.GetAllAsync());
                }
            );

            app.MapGet("/api/entries/{id}",
                async ([FromRoute] Guid id, [FromServices] IEntryRepository repository) =>
                {
                    var entry = await repository.GetAsync(id);
                    return entry is not null ? Results.Ok(entry) : Results.NotFound();
                }
            );

            app.MapPost("/api/entries",
                async ([FromBody] Entry entry, [FromServices] IEntryRepository repository) =>
                {
                    entry.Id = Guid.NewGuid();
                    await repository.AddAsync(entry);
                    return Results.Created($"/api/entries/{entry.Id}", entry);
                }
            );

            app.MapPut("/api/entries/{id}",
                async ([FromRoute] Guid id, [FromBody] Entry entry, [FromServices] IEntryRepository repository) =>
                {
                    var existingEntry = await repository.GetAsync(id);
                    if (existingEntry is null)
                        return Results.NotFound();

                    entry.Id = id;
                    await repository.UpdateAsync(entry);
                    return Results.Ok(entry);
                }
            );

            app.MapDelete("/api/entries/{id}",
                async ([FromRoute] Guid id, [FromServices] IEntryRepository repository) =>
                {
                    var entry = await repository.GetAsync(id);
                    if (entry is null)
                        return Results.NotFound();

                    await repository.DeleteAsync(id);
                    return Results.NoContent();
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