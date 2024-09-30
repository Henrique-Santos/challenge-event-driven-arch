using System.Reflection;
using EDA.Core.Mediator;
using EDA.Core.MessageBus;
using EDA.Wallet.Application.Commands;
using EDA.Wallet.Application.Queries;
using EDA.Wallet.Configuration;
using EDA.Wallet.Data;
using EDA.Wallet.Data.Repository;
using EDA.Wallet.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//

builder.Services.AddMessageBus(builder.Configuration.GetConnectionString("MessageBusConnection"));

builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<WalletContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<IRequestHandler<CreateClientCommand, bool>, ClientCommandHandler>();

builder.Services.AddScoped<IRequestHandler<CreateAccountCommand, bool>, AccountCommandHandler>();

builder.Services.AddScoped<IRequestHandler<CreateTransactionCommand, bool>, TransactionCommandHandler>();

builder.Services.AddScoped<IClientQueries, ClientQueries>();

builder.Services.AddScoped<IAccountQueries, AccountQueries>();

builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

builder.Services.AddScoped<WalletContext>();

//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//

DbMigrationHelpers.EnsureSeedData(app).Wait();

//

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();