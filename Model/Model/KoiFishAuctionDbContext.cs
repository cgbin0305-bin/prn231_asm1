using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.Model;

public partial class KoiFishAuctionDbContext : DbContext
{
    public KoiFishAuctionDbContext()
    {
    }

    public KoiFishAuctionDbContext(DbContextOptions<KoiFishAuctionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuctionHistory> AuctionHistories { get; set; }

    public virtual DbSet<AuctionItem> AuctionItems { get; set; }

    public virtual DbSet<AuctionSession> AuctionSessions { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=FA24_NET1720_PRN231_G6_KoiFishAuction;Uid=sa;Pwd=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuctionHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__AuctionH__4D7B4ADDC9A2F1A4");

            entity.ToTable("AuctionHistory");

            entity.Property(e => e.HistoryId).HasColumnName("HistoryID");
            entity.Property(e => e.DeliveryStatus).HasMaxLength(50);
            entity.Property(e => e.FeedbackStatus).HasMaxLength(50);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.OwnerUserId).HasColumnName("OwnerUserID");
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(250);
            entity.Property(e => e.WinnerUserId).HasColumnName("WinnerUserID");
            entity.Property(e => e.WinningBidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WinningDate).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.AuctionHistories)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__AuctionHi__ItemI__4316F928");

            entity.HasOne(d => d.OwnerUser).WithMany(p => p.AuctionHistoryOwnerUsers)
                .HasForeignKey(d => d.OwnerUserId)
                .HasConstraintName("FK__AuctionHi__Owner__440B1D61");

            entity.HasOne(d => d.WinnerUser).WithMany(p => p.AuctionHistoryWinnerUsers)
                .HasForeignKey(d => d.WinnerUserId)
                .HasConstraintName("FK__AuctionHi__Winne__44FF419A");
        });

        modelBuilder.Entity<AuctionItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__AuctionI__727E83EBEE7E3B67");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(250)
                .HasColumnName("ImageURL");
            entity.Property(e => e.ItemName).HasMaxLength(150);
            entity.Property(e => e.KoiOrigin).HasMaxLength(150);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StartPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<AuctionSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__AuctionS__C9F492706F8975FD");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.CurrentHighestBid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CurrentHighestBidderId).HasColumnName("CurrentHighestBidderID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.MinBidIncrement).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SessionName).HasMaxLength(150);
            entity.Property(e => e.SessionNote).HasMaxLength(250);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CurrentHighestBidder).WithMany(p => p.AuctionSessions)
                .HasForeignKey(d => d.CurrentHighestBidderId)
                .HasConstraintName("FK__AuctionSe__Curre__45F365D3");

            entity.HasOne(d => d.Item).WithMany(p => p.AuctionSessions)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__AuctionSe__ItemI__46E78A0C");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasKey(e => e.BidId).HasName("PK__Bids__4A733DB2FA16ED4E");

            entity.Property(e => e.BidId).HasColumnName("BidID");
            entity.Property(e => e.BidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BidCurrency).HasMaxLength(10);
            entity.Property(e => e.BidSource).HasMaxLength(100);
            entity.Property(e => e.BidTime).HasColumnType("datetime");
            entity.Property(e => e.BidTimestamp).HasColumnType("datetime");
            entity.Property(e => e.BidderNote).HasMaxLength(250);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Item).WithMany(p => p.Bids)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Bids__ItemID__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Bids)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bids__UserID__48CFD27E");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E32CE2B34FB");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.BidId).HasColumnName("BidID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NotificationDate).HasColumnType("datetime");
            entity.Property(e => e.NotificationType).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(250);
            entity.Property(e => e.SenderUserId).HasColumnName("SenderUserID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Bid).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.BidId)
                .HasConstraintName("FK__Notificat__BidID__49C3F6B7");

            entity.HasOne(d => d.Item).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Notificat__ItemI__4AB81AF0");

            entity.HasOne(d => d.SenderUser).WithMany(p => p.NotificationSenderUsers)
                .HasForeignKey(d => d.SenderUserId)
                .HasConstraintName("FK__Notificat__Sende__4BAC3F29");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__4CA06362");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A5800156C79");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Currency).HasMaxLength(10);
            entity.Property(e => e.HistoryId).HasColumnName("HistoryID");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(250);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("TransactionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.History).WithMany(p => p.Payments)
                .HasForeignKey(d => d.HistoryId)
                .HasConstraintName("FK__Payment__History__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payment__UserID__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACC936C874");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UserNote).HasMaxLength(250);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
