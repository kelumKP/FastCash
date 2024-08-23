using Microsoft.EntityFrameworkCore;
using LoanApp.Infrastructure.Data;
using LoanApp.Infrastructure.Interfaces;
using LoanApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);



// Add DbContext and other services
builder.Services.AddDbContext<LoansUnlimitedContext>(options =>
    options.UseSqlite("Data Source=loanapp.db"));

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