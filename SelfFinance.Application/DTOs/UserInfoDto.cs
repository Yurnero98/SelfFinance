namespace SelfFinance.Application.DTOs;

public class UserInfoDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}