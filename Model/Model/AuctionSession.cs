using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class AuctionSession
{
    public int SessionId { get; set; }

    public int? ItemId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal MinBidIncrement { get; set; }

    public decimal? CurrentHighestBid { get; set; }

    public int? CurrentHighestBidderId { get; set; }

    public bool? IsActive { get; set; }

    public string? SessionName { get; set; }

    public string? SessionNote { get; set; }

    public virtual User? CurrentHighestBidder { get; set; }

    public virtual AuctionItem? Item { get; set; }
}
