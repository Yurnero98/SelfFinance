namespace SelfFinance.Domain.Entities;

public class FinancialOperation
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = null!;

    public int TransactionTypeId { get; set; }
    public TransactionType TransactionType { get; set; } = null!;

    public int UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;
}