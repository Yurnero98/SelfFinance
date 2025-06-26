using SelfFinance.Application.DTOs;

namespace SelfFinance.Blazor.Services;

public class ReportService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ReportDto?> GetDailyReportAsync(DateTime date)
    {
        return await _httpClient.GetFromJsonAsync<ReportDto>($"api/reports/daily?date={date:yyyy-MM-dd}");
    }

    public async Task<ReportDto?> GetPeriodReportAsync(DateTime start, DateTime end)
    {
        return await _httpClient.GetFromJsonAsync<ReportDto>($"api/reports/period?start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}");
    }
}