using Microsoft.EntityFrameworkCore;
using SelfFinance.Domain.Entities;
using SelfFinance.Domain.Interfaces;
using SelfFinance.Infrastructure.Data;

namespace SelfFinance.Infrastructure.Repositories;

public class FinancialOperationRepository(AppDbContext context) : IFinancialOperationRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<FinancialOperation>> GetAllByUserIdAsync(int userId) =>
        await _context.FinancialOperations
            .Include(f => f.TransactionType)
            .Where(f => f.UserId == userId)
            .ToListAsync();

    public async Task<FinancialOperation?> GetByIdAndUserIdAsync(int id, int userId) =>
        await _context.FinancialOperations
            .Include(f => f.TransactionType)
            .FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId);

    public async Task<FinancialOperation> AddAsync(FinancialOperation operation)
    {
        _context.FinancialOperations.Add(operation);
        await _context.SaveChangesAsync();
        return operation;
    }

    public async Task<bool> UpdateAsync(FinancialOperation operation)
    {
        var existing = await _context.FinancialOperations
            .FirstOrDefaultAsync(f => f.Id == operation.Id && f.UserId == operation.UserId);

        if (existing == null)
            return false;

        _context.Entry(existing).CurrentValues.SetValues(operation);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByIdAndUserIdAsync(int id, int userId)
    {
        var existing = await _context.FinancialOperations
            .FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId);

        if (existing == null)
            return false;

        _context.FinancialOperations.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<FinancialOperation>> GetByDateAsync(DateTime date, int userId)
    {
        var start = date.Date;      
        var end = start.AddDays(1);        

        return await _context.FinancialOperations
            .Include(x => x.TransactionType)
            .Where(x => x.UserId == userId && x.Date >= start && x.Date < end)
            .ToListAsync();
    }

    public async Task<List<FinancialOperation>> GetByPeriodAsync(DateTime startDate, DateTime endDate, int userId)
    {
        return await _context.FinancialOperations
            .Include(op => op.TransactionType)
            .Where(op => op.Date >= startDate && op.Date <= endDate && op.UserId == userId)
            .ToListAsync();
    }
}