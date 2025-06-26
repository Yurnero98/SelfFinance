namespace SelfFinance.Application.DTOs.TransactionType;

public class TransactionTypeDto 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsIncome { get; set; }
}