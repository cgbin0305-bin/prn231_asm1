using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class AuctionHistory
{
    public int HistoryId { get; set; }

    public int? ItemId { get; set; }

    public int? WinnerUserId { get; set; }

    public decimal WinningBidAmount { get; set; }

    public DateTime WinningDate { get; set; }

    public string? PaymentStatus { get; set; }

    public string? DeliveryStatus { get; set; }

    public int? OwnerUserId { get; set; }

    public string? FeedbackStatus { get; set; }

    public string? Remarks { get; set; }

    public virtual AuctionItem? Item { get; set; }

    public virtual User? OwnerUser { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? WinnerUser { get; set; }
}
