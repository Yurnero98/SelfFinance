using Microsoft.EntityFrameworkCore;
using SelfFinance.Domain.Entities;
using SelfFinance.Domain.Interfaces;
using SelfFinance.Infrastructure.Data;

namespace SelfFinance.Infrastructure.Repositories;

public class TransactionTypeRepository(AppDbContext context) : ITransactionTypeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<TransactionType>> GetAllByUserIdAsync(int userId)
    {
        return await _context.TransactionTypes.Where(t => t.UserId == userId).ToListAsync();
    }

    public async Task<TransactionType?> GetByIdAndUserIdAsync(int id, int userId)
    {
        return await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
    }

    public async Task<TransactionType?> GetByNameAndUserIdAsync(string name, int userId)
    {
        return await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Name == name && t.UserId == userId);
    }

    public async Task<TransactionType> AddAsync(TransactionType entity)
    {
        _context.TransactionTypes.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(TransactionType entity)
    {
        var existing = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Id == entity.Id && t.UserId == entity.UserId);
        if (existing == null)
            return false;

        _context.Entry(existing).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByIdAndUserIdAsync(int id, int userId)
    {
        var entity = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        if (entity == null)
            return false;

        _context.TransactionTypes.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}