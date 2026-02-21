using Serilog;
using CaraCara.Application;
using CaraCara.Application.Features.Vehicles.Queries.GetVehicles;
using MediatR;
using CaraCara.Infrastructure;
using CaraCara.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application Layer Services
builder.Services.AddApplicationServices();

// Add Infrastructure Layer Services (DbContext, Identity, Repositories)
builder.Services.AddInfrastructureServices(builder.Configuration);

// 🧾 Cấu hình Serilog basic ghi log ra file logs/log-.txt
builder.Host.UseAppSerilog();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging(); //bật auto lưu các HTTP request k cần gọi ILog

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/api/vehicles", async (IMediator mediator) =>
{
    var query = new GetVehiclesQuery();
    var result = await mediator.Send(query);
    return Results.Ok(result);
})
.WithName("GetVehicles")
.WithOpenApi();

app.Run();