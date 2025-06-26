using AutoMapper;
using SelfFinance.Application.DTOs;
using SelfFinance.Application.DTOs.FinancialOperation;
using SelfFinance.Application.Interfaces;
using SelfFinance.Domain.Entities;
using SelfFinance.Domain.Interfaces;

namespace SelfFinance.Application.Services;

public class FinancialOperationService(IFinancialOperationRepository repository, IMapper mapper) : IFinancialOperationService
{
    private readonly IFinancialOperationRepository _financialOpetationRepository = repository;
    private readonly IMapper _financialOpetationMapper = mapper;

    public async Task<IEnumerable<FinancialOperationDto>> GetAllAsync(int userId)
    {
        var entities = await _financialOpetationRepository.GetAllByUserIdAsync(userId);
        return _financialOpetationMapper.Map<IEnumerable<FinancialOperationDto>>(entities);
    }

    public async Task<FinancialOperationDto?> GetByIdAsync(int id, int userId)
    {
        var entity = await _financialOpetationRepository.GetByIdAndUserIdAsync(id, userId);
        return entity == null ? null : _financialOpetationMapper.Map<FinancialOperationDto>(entity);
    }

    public async Task<FinancialOperationDto> CreateAsync(FinancialOperationCreateDto dto, int userId)
    {
        var entity = _financialOpetationMapper.Map<FinancialOperation>(dto);
        entity.UserId = userId;
        entity.Date = DateTime.Now;
        var created = await _financialOpetationRepository.AddAsync(entity);
        return _financialOpetationMapper.Map<FinancialOperationDto>(created);
    }

    public async Task<bool> UpdateAsync(int id, FinancialOperationUpdateDto dto, int userId)
    {
        var entity = _financialOpetationMapper.Map<FinancialOperation>(dto);
        entity.Id = id;
        entity.UserId = userId;
        return await _financialOpetationRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id, int userId)
    {
        return await _financialOpetationRepository.DeleteByIdAndUserIdAsync(id, userId);
    }

    public async Task<ReportDto> GetByDateAsync(DateTime date, int userId)
    {
        var operations = await _financialOpetationRepository.GetByDateAsync(date, userId);
        return BuildReport(operations);
    }

    public async Task<ReportDto> GetByPeriodAsync(DateTime startDate, DateTime endDate, int userId)
    {
        var operations = await _financialOpetationRepository.GetByPeriodAsync(startDate, endDate, userId);
        return BuildReport(operations);
    }

    private ReportDto BuildReport(List<FinancialOperation> operations)
    {
        var dtos = _financialOpetationMapper.Map<List<FinancialOperationDto>>(operations);
        return new ReportDto
        {
            Operations = dtos,
            TotalIncome = operations.Where(o => o.TransactionType.IsIncome).Sum(o => o.Amount),
            TotalExpenses = operations.Where(o => !o.TransactionType.IsIncome).Sum(o => o.Amount)
        };
    }
}