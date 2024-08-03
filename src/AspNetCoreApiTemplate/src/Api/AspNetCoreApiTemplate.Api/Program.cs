using AspNetCoreApiTemplate.Api.Extensions;
using AspNetCoreApiTemplate.Common.Presentation.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandling();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddModules();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.UseExceptionHandler();

app.UseHttpsRedirection();

await app.RunAsync();