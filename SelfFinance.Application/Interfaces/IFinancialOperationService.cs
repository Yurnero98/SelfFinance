using SelfFinance.Application.DTOs;
using SelfFinance.Application.DTOs.FinancialOperation;

namespace SelfFinance.Application.Interfaces;

public interface IFinancialOperationService
{
    Task<IEnumerable<FinancialOperationDto>> GetAllAsync(int userId);
    Task<FinancialOperationDto?> GetByIdAsync(int id, int userId);
    Task<FinancialOperationDto> CreateAsync(FinancialOperationCreateDto dto, int userId);
    Task<bool> UpdateAsync(int id, FinancialOperationUpdateDto dto, int userId);
    Task<bool> DeleteAsync(int id, int userId);
    Task<ReportDto> GetByDateAsync(DateTime date, int userId);
    Task<ReportDto> GetByPeriodAsync(DateTime startDate, DateTime endDate, int userId);
}