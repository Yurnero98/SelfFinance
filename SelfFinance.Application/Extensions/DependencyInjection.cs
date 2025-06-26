using Microsoft.Extensions.DependencyInjection;
using SelfFinance.Application.Interfaces;
using SelfFinance.Application.Services;

namespace SelfFinance.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITransactionTypeService, TransactionTypeService>();
        services.AddScoped<IFinancialOperationService, FinancialOperationService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        return services;
    }
}