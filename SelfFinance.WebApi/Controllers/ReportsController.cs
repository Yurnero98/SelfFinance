using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfFinance.Application.DTOs;
using SelfFinance.Application.Interfaces;
using SelfFinance.WebApi.Extensions;

namespace SelfFinance.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReportsController(IFinancialOperationService service) : ControllerBase
{
    private readonly IFinancialOperationService _financialOperationService = service;

    [HttpGet("daily")]
    public async Task<ActionResult<ReportDto>> GetDailyReport([FromQuery] DateTime date)
    {
        var userId = User.GetId();
        var report = await _financialOperationService.GetByDateAsync(date, userId);
        return Ok(report);
    }

    [HttpGet("period")]
    public async Task<ActionResult<ReportDto>> GetByPeriodAsync([FromQuery] DateTime start, [FromQuery] DateTime end)
    {
        if (end < start)
            return BadRequest("End date must be greater than or equal to start date");

        var userId = User.GetId();
        var report = await _financialOperationService.GetByPeriodAsync(start, end, userId);
        return Ok(report);
    }
}