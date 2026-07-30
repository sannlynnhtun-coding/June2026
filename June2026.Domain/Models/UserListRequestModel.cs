namespace June2026.Domain.Models;

public class UserListRequestModel
{

}

public class UserListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<UserModel> Users { get; set; }
}

public class UserModel
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;
}
