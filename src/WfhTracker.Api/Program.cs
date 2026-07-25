using Microsoft.IdentityModel.Logging;
using WfhTracker.Api.Extensions;
using WfhTracker.Api.Models;
using WfhTracker.Api.Repositories;
using WfhTracker.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCorsPolicy(builder.Configuration);
builder.Services.AddJwtBearerExtension(builder.Configuration);

builder.Services.AddSingleton<IEntryRepository, BlobEntryRepository>();
builder.Services.AddSingleton<IBlobStorageService, BlobStorageService>();

builder.Services.Configure<StorageOptions>(
    builder.Configuration.GetSection("Storage"));

IdentityModelEventSource.ShowPII = true;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("BlazorClient");

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();
