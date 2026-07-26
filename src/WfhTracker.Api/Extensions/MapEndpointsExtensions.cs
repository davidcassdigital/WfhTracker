using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Security.Claims;
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
            var group = app.MapGroup("/api/entries")
                .WithTags("Entries")
                .RequireAuthorization()
                .WithOpenApi();

            // Could be improved by moving out to a separate class for each endpoint.
            group.MapGet("/",
                async (ClaimsPrincipal user,
                    [FromServices] IEntryRepository repository,
                    ILogger<Program> logger) =>
                {
                    //var userId = user.GetObjectId() ??
                    //    throw new UnauthorizedAccessException();

                    var userId = user.GetObjectId();

                    logger.LogInformation("Authenticated user id: {UserId}", userId);

                    return userId is null
                        ? Results.Unauthorized()
                        : Results.Ok(await repository.GetAllAsync(userId));
                }
            );

            group.MapGet("/{id:guid}",
                async (ClaimsPrincipal user, [FromRoute] Guid id, [FromServices] IEntryRepository repository) =>
                {
                    var userId = user.GetObjectId() ??
                        throw new UnauthorizedAccessException();

                    var entry = await repository.GetAsync(userId, id);
                    return entry is not null ? Results.Ok(entry) : Results.NotFound();
                }
            );

            group.MapPost("/",
                async (ClaimsPrincipal user, [FromBody] Entry entry, [FromServices] IEntryRepository repository) =>
                {
                    var userId = user.GetObjectId() ??
                        throw new UnauthorizedAccessException();

                    entry.Id = Guid.NewGuid();
                    await repository.AddAsync(userId, entry);
                    return Results.Created($"/api/entries/{entry.Id}", entry);
                }
            );

            group.MapPut("/{id:guid}",
                async (ClaimsPrincipal user, [FromRoute] Guid id, [FromBody] Entry entry, [FromServices] IEntryRepository repository) =>
                {
                    var userId = user.GetObjectId() ??
                        throw new UnauthorizedAccessException();

                    var existingEntry = await repository.GetAsync(userId, id);
                    if (existingEntry is null)
                        return Results.NotFound();

                    entry.Id = id;
                    await repository.UpdateAsync(userId, entry);
                    return Results.Ok(entry);
                }
            );

            group.MapDelete("/{id:guid}",
                async (ClaimsPrincipal user, [FromRoute] Guid id, [FromServices] IEntryRepository repository) =>
                {
                    var userId = user.GetObjectId() ??
                        throw new UnauthorizedAccessException();

                    var entry = await repository.GetAsync(userId, id);
                    if (entry is null)
                        return Results.NotFound();

                    await repository.DeleteAsync(userId, id);
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