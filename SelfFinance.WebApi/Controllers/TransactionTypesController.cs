using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfFinance.Application.DTOs.TransactionType;
using SelfFinance.Application.Interfaces;
using SelfFinance.WebApi.Extensions;

namespace SelfFinance.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class TransactionTypesController(ITransactionTypeService service) : ControllerBase
{
    private readonly ITransactionTypeService _transactionTypeService = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionTypeDto>>> GetAll()
    {
        var userId = User.GetId();
        var items = await _transactionTypeService.GetAllAsync(userId);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionTypeDto>> Get(int id)
    {
        var userId = User.GetId();
        var item = await _transactionTypeService.GetByIdAsync(id, userId);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Create(TransactionTypeCreateDto dto)
    {
        var userId = User.GetId();

        try
        {
            var created = await _transactionTypeService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, TransactionTypeUpdateDto dto)
    {
        var userId = User.GetId();

        try
        {
            var success = await _transactionTypeService.UpdateAsync(id, dto, userId);
            if (!success) return NotFound();
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var userId = User.GetId();
        var success = await _transactionTypeService.DeleteAsync(id, userId);
        if (!success) return NotFound();
        return NoContent();
    }
}