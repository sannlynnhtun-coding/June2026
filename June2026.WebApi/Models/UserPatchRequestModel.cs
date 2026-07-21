namespace June2026.WebApi.Models;

public class UserPatchRequestModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}

public class UserPatchResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}