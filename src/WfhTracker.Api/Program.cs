using WfhTracker.Api.Extensions;
using WfhTracker.Api.Models;
using WfhTracker.Api.Repositories;
using WfhTracker.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsPolicy = builder.Configuration.GetSection("CorsPolicy:WithOrigins").Get<string[]>();

// Could move these to an extension class
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
    {
        policy.WithOrigins(corsPolicy ?? ["https://localhost:7154"]);
    });
});

builder.Services.AddSingleton<IEntryRepository, BlobEntryRepository>();
builder.Services.AddSingleton<IBlobStorageService, BlobStorageService>();

builder.Services.Configure<StorageOptions>(
    builder.Configuration.GetSection("Storage"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("BlazorClient");

app.MapEndpoints();

app.Run();
