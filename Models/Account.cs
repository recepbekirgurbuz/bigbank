using System;
using System.Collections.Generic;

namespace bigbank.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public int? CustomerId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public decimal? Balance { get; set; }

    public string? AccountType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Customer? Customer { get; set; }
}
