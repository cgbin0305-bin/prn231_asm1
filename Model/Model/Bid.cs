using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class Bid
{
    public int BidId { get; set; }

    public int? UserId { get; set; }

    public int? ItemId { get; set; }

    public decimal BidAmount { get; set; }

    public DateTime BidTime { get; set; }

    public string? BidderNote { get; set; }

    public bool? IsWinningBid { get; set; }

    public string? BidSource { get; set; }

    public string? BidCurrency { get; set; }

    public DateTime? BidTimestamp { get; set; }

    public virtual AuctionItem? Item { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual User? User { get; set; }
}
