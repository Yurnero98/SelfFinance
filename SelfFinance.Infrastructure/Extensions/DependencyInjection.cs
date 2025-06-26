using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelfFinance.Domain.Interfaces;
using SelfFinance.Infrastructure.Data;
using SelfFinance.Infrastructure.Repositories;

namespace SelfFinance.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString)); 

        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IFinancialOperationRepository, FinancialOperationRepository>();

        return services;
    }
}