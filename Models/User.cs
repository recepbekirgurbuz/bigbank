﻿using System;
using System.Collections.Generic;

namespace bigbank.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }
}
