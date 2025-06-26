using Microsoft.AspNetCore.Identity;

namespace SelfFinance.Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{
    public ICollection<FinancialOperation> FinancialOperations { get; set; } = [];
    public ICollection<TransactionType> TransactionTypes { get; set; } = [];
}