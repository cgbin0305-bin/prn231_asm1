using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? HistoryId { get; set; }

    public int? UserId { get; set; }

    public decimal PaymentAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public string? TransactionId { get; set; }

    public string? Remarks { get; set; }

    public string? Currency { get; set; }

    public virtual AuctionHistory? History { get; set; }

    public virtual User? User { get; set; }
}
