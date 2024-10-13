using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int? UserId { get; set; }

    public int? ItemId { get; set; }

    public string? Message { get; set; }

    public string? NotificationType { get; set; }

    public bool? IsRead { get; set; }

    public DateTime NotificationDate { get; set; }

    public int? BidId { get; set; }

    public int? SenderUserId { get; set; }

    public string? Remarks { get; set; }

    public virtual Bid? Bid { get; set; }

    public virtual AuctionItem? Item { get; set; }

    public virtual User? SenderUser { get; set; }

    public virtual User? User { get; set; }
}
