using System;
using System.Collections.Generic;

namespace Persistance.Models;

public partial class User
{
    public string? UserName { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int UserId { get; set; }

    public int? RoleId { get; set; }
}
