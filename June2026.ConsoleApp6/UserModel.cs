using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp6;

public class UserModel
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}

public class UserCreateRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UserCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
}

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