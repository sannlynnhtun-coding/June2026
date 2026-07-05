using System;
using System.Collections.Generic;

namespace June2026.Database.AppDbContextModels;

public partial class TblUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
