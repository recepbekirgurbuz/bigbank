using System;
using System.Collections.Generic;

namespace bigbank.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int FromAccountId { get; set; }

    public int ToAccountId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? Descriptions { get; set; }
}
