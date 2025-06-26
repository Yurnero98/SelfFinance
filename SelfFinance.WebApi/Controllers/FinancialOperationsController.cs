using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfFinance.Application.DTOs.FinancialOperation;
using SelfFinance.Application.Interfaces;
using SelfFinance.WebApi.Extensions;

namespace SelfFinance.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FinancialOperationsController(IFinancialOperationService service) : ControllerBase
{
    private readonly IFinancialOperationService _financialOperationService = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FinancialOperationDto>>> GetAll()
    {
        var userId = User.GetId();
        var operations = await _financialOperationService.GetAllAsync(userId);
        return Ok(operations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FinancialOperationDto>> Get(int id)
    {
        var userId = User.GetId();
        var operation = await _financialOperationService.GetByIdAsync(id, userId);
        if (operation == null) return NotFound();
        return Ok(operation);
    }

    [HttpPost]
    public async Task<ActionResult> Create(FinancialOperationCreateDto dto)
    {
        var userId = User.GetId();
        var created = await _financialOperationService.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, FinancialOperationUpdateDto dto)
    {
        var userId = User.GetId();
        var success = await _financialOperationService.UpdateAsync(id, dto, userId);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var userId = User.GetId();
        var success = await _financialOperationService.DeleteAsync(id, userId);
        if (!success) return NotFound();
        return NoContent();
    }
}