namespace SelfFinance.Application.DTOs.FinancialOperation;

public class FinancialOperationDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public int TransactionTypeId { get; set; }
}