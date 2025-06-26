using System.ComponentModel.DataAnnotations;

namespace SelfFinance.Application.DTOs.FinancialOperation;

public class FinancialOperationCreateDto
{
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Transaction type is required.")]
    public int? TransactionTypeId { get; set; }
}