using SelfFinance.Domain.Entities;

namespace SelfFinance.Domain.Interfaces;

public interface ITransactionTypeRepository
{
    Task<TransactionType> AddAsync(TransactionType type);
    Task<bool> UpdateAsync(TransactionType type);
    Task<IEnumerable<TransactionType>> GetAllByUserIdAsync(int userId);
    Task<TransactionType?> GetByIdAndUserIdAsync(int id, int userId);
    Task<TransactionType?> GetByNameAndUserIdAsync(string name, int userId);
    Task<bool> DeleteByIdAndUserIdAsync(int id, int userId);
}