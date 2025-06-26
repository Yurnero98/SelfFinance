namespace SelfFinance.Domain.Entities;

public class TransactionType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsIncome { get; set; }

    public int UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;
}