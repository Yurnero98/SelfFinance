using SelfFinance.Application.DTOs.FinancialOperation;

namespace SelfFinance.Blazor.Services;

public class FinancialOperationService
{
    private readonly HttpClient _httpClient;

    public FinancialOperationService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<List<FinancialOperationDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<FinancialOperationDto>>("api/financialoperations") ?? new();
    }

    public async Task<FinancialOperationDto?> CreateAsync(FinancialOperationCreateDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/financialoperations", dto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<FinancialOperationDto>();
        }

        return null;
    }

    public async Task<bool> UpdateAsync(int id, FinancialOperationUpdateDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/financialoperations/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/financialoperations/{id}");
        return response.IsSuccessStatusCode;
    }
}