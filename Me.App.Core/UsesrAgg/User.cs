using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.UserAgg;
public class User
{
    [PrimaryKey, AutoIncrement] 
    public int Id { get; set; } = 1;
    public string Nickname { get; set; } = string.Empty;
    public string ProfileImagePath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
