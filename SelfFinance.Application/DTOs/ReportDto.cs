using SelfFinance.Application.DTOs.FinancialOperation;

namespace SelfFinance.Application.DTOs;

public class ReportDto
{
    public decimal TotalIncome { get; set; }
    public decimal TotalExpenses { get; set; }
    public List<FinancialOperationDto> Operations { get; set; } = [];
}