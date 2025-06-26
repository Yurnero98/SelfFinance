using AutoMapper;
using SelfFinance.Application.DTOs.TransactionType;
using SelfFinance.Application.Interfaces;
using SelfFinance.Domain.Entities;
using SelfFinance.Domain.Interfaces;

namespace SelfFinance.Application.Services;

public class TransactionTypeService(ITransactionTypeRepository repository, IMapper mapper) : ITransactionTypeService
{
    private readonly ITransactionTypeRepository _transactionTypeRepository = repository;
    private readonly IMapper _transactionTypeMapper = mapper;

    public async Task<IEnumerable<TransactionTypeDto>> GetAllAsync(int userId)
    {
        var entities = await _transactionTypeRepository.GetAllByUserIdAsync(userId);
        return _transactionTypeMapper.Map<IEnumerable<TransactionTypeDto>>(entities);
    }

    public async Task<TransactionTypeDto?> GetByIdAsync(int id, int userId)
    {
        var entity = await _transactionTypeRepository.GetByIdAndUserIdAsync(id, userId);
        return entity == null ? null : _transactionTypeMapper.Map<TransactionTypeDto>(entity);
    }

    public async Task<TransactionTypeDto> CreateAsync(TransactionTypeCreateDto dto, int userId)
    {
        var existing = await _transactionTypeRepository.GetByNameAndUserIdAsync(dto.Name, userId);
        if (existing != null)
            throw new InvalidOperationException("Transaction type with this name already exists.");

        var entity = _transactionTypeMapper.Map<TransactionType>(dto);
        entity.UserId = userId;
        var created = await _transactionTypeRepository.AddAsync(entity);
        return _transactionTypeMapper.Map<TransactionTypeDto>(created);
    }

    public async Task<bool> UpdateAsync(int id, TransactionTypeUpdateDto dto, int userId)
    {
        var existing = await _transactionTypeRepository.GetByNameAndUserIdAsync(dto.Name, userId);
        if (existing != null && existing.Id != id)
            throw new InvalidOperationException("Another transaction type with this name already exists.");

        var entity = _transactionTypeMapper.Map<TransactionType>(dto);
        entity.Id = id;
        entity.UserId = userId;
        return await _transactionTypeRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id, int userId)
    {
        return await _transactionTypeRepository.DeleteByIdAndUserIdAsync(id, userId);
    }
}