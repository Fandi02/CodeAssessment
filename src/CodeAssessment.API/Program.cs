using CodeAssessment.Application.Business;
using CodeAssessment.Application.Business.CarsProduction.Commands;
using CodeAssessment.Application.Interface;
using CodeAssessment.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarsProductionService, CarsProductionService>();
builder.Services.AddScoped<IGetListCarsProductionQuery, GetListCarsProductionQuery>();
builder.Services.AddScoped<IGetCarsProductionByIdQuery, GetCarsProductionByIdQuery>();
builder.Services.AddTransient<ISaveProductionCommand, SaveCarsProduction>();
builder.Services.AddTransient<IAppDbContext, AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
