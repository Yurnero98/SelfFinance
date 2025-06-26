using System.ComponentModel.DataAnnotations;

namespace SelfFinance.Application.DTOs.TransactionType;

public class TransactionTypeCreateDto 
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;
    public bool IsIncome { get; set; }
}