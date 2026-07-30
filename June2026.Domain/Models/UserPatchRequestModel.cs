namespace June2026.Domain.Models;

public class UserPatchRequestModel
{
    public int UserId { get; set; } 
    public string? Username { get; set; }
    public string? Password { get; set; }
}

public class UserPatchResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}