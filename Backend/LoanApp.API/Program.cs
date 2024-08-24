using Microsoft.EntityFrameworkCore;
using LoanApp.Infrastructure.Data;
using LoanApp.Infrastructure.Interfaces;
using LoanApp.Infrastructure.Services;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Specify the absolute path for the SQLite database
var dbDirectory = Path.Combine("..", "LoanApp.Infrastructure", "Data");
var dbPath = Path.Combine(dbDirectory, "loanapp.db");

// Add CORS policy
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);

// Add DbContext and other services
builder.Services.AddDbContext<LoansUnlimitedContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<ILoanApplicationService, LoanApplicationService>();

var app = builder.Build();

app.UseCors();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LoansUnlimitedContext>();
    context.Database.EnsureCreated();
}

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