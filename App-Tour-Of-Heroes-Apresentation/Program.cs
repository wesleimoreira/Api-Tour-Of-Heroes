using App_Tour_Of_Heroes_Apresentation.Extensions;
using Api_Tour_Of_Heroes_Application.DependencyInjections;
using Api_Tour_Of_Heroes_Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();
builder.Services.AddApplicationDependencyInjection();
builder.Services.AddInfrastructureDependencyInjection(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
