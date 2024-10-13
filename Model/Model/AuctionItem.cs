using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class AuctionItem
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal StartPrice { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Category { get; set; }

    public string? Status { get; set; }

    public string? ImageUrl { get; set; }

    public int? KoiAge { get; set; }

    public string? KoiOrigin { get; set; }

    public virtual ICollection<AuctionHistory> AuctionHistories { get; set; } = new List<AuctionHistory>();

    public virtual ICollection<AuctionSession> AuctionSessions { get; set; } = new List<AuctionSession>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
