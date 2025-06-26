using SelfFinance.Domain.Entities;

namespace SelfFinance.Domain.Interfaces;

public interface IFinancialOperationRepository
{
    Task<IEnumerable<FinancialOperation>> GetAllByUserIdAsync(int userId);
    Task<FinancialOperation?> GetByIdAndUserIdAsync(int id, int userId);
    Task<FinancialOperation> AddAsync(FinancialOperation operation);
    Task<bool> UpdateAsync(FinancialOperation operation);
    Task<bool> DeleteByIdAndUserIdAsync(int id, int userId);
    Task<List<FinancialOperation>> GetByDateAsync(DateTime date, int userId);
    Task<List<FinancialOperation>> GetByPeriodAsync(DateTime startDate, DateTime endDate, int userId);
}