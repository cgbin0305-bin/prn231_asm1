using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? UserNote { get; set; }

    public virtual ICollection<AuctionHistory> AuctionHistoryOwnerUsers { get; set; } = new List<AuctionHistory>();

    public virtual ICollection<AuctionHistory> AuctionHistoryWinnerUsers { get; set; } = new List<AuctionHistory>();

    public virtual ICollection<AuctionSession> AuctionSessions { get; set; } = new List<AuctionSession>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Notification> NotificationSenderUsers { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationUsers { get; set; } = new List<Notification>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
