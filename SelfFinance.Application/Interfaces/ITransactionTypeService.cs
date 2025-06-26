using SelfFinance.Application.DTOs.TransactionType;

namespace SelfFinance.Application.Interfaces;

public interface ITransactionTypeService
{
    Task<IEnumerable<TransactionTypeDto>> GetAllAsync(int userId);
    Task<TransactionTypeDto?> GetByIdAsync(int id, int userId);
    Task<TransactionTypeDto> CreateAsync(TransactionTypeCreateDto dto, int userId);
    Task<bool> UpdateAsync(int id, TransactionTypeUpdateDto dto, int userId);
    Task<bool> DeleteAsync(int id, int userId);
}