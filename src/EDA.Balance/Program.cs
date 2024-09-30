using EDA.Balance.Data;
using EDA.Balance.Data.Repository;
using EDA.Balance.Domain.Repository;
using EDA.Balance.Services;
using EDA.Core.MessageBus;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//

builder.Services.AddMessageBus(builder.Configuration.GetConnectionString("MessageBusConnection"))
    .AddHostedService<TransactionEventHandler>()
    .AddHostedService<BalanceEventHandler>();

builder.Services.AddDbContext<BalanceContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<BalanceContext>();

//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();