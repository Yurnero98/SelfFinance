using SelfFinance.Application.DTOs.TransactionType;

namespace SelfFinance.Blazor.Services;

public class TransactionTypeService
{
    private readonly HttpClient _httpClient;

    public TransactionTypeService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<List<TransactionTypeDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<TransactionTypeDto>>("api/transactiontypes") ?? new();
    }

    public async Task<bool> CreateAsync(TransactionTypeCreateDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/transactiontypes", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(int id, TransactionTypeUpdateDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/transactiontypes/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/transactiontypes/{id}");
        return response.IsSuccessStatusCode;
    }
}