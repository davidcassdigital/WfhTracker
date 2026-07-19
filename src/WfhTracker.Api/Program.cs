using WfhTracker.Api.Extensions;
using WfhTracker.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsPolicy = builder.Configuration.GetSection("CorsPolicy:WithOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
    {
        policy.WithOrigins(corsPolicy ?? ["https://localhost:7154"]);
    });
});

builder.Services.AddSingleton<IEntryRepository, InMemoryEntryRepository>();

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
