
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapiStay.Infrastructure.Persistence;

public class CapiStayDbContext : DbContext
{
    public CapiStayDbContext(
        DbContextOptions<CapiStayDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Season> Seasons => Set<Season>();
    public DbSet<SeasonalRate> SeasonalRates => Set<SeasonalRate>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<BookingNight> BookingNights => Set<BookingNight>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<RoomBlock> RoomBlocks => Set<RoomBlock>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<CouponRoomType> CouponRoomTypes => Set<CouponRoomType>();
    public DbSet<CouponRedemption> CouponRedemptions => Set<CouponRedemption>();
    public DbSet<RoomTypeImage> RoomTypeImages => Set<RoomTypeImage>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<RoomTypeAmenity> RoomTypeAmenities => Set<RoomTypeAmenity>();
    public DbSet<HotelSettings> HotelSettings => Set<HotelSettings>();
    public DbSet<HotelService> HotelServices => Set<HotelService>();
    public DbSet<Promotion> Promotions => Set<Promotion>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<EmailNotification> EmailNotifications => Set<EmailNotification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<BookingAuditLog> BookingAuditLogs => Set<BookingAuditLog>();
    public DbSet<BookingModification> BookingModifications => Set<BookingModification>();
    public DbSet<Refund> Refunds => Set<Refund>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<EmailVerificationToken> EmailVerificationTokens => Set<EmailVerificationToken>();
    public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();
    public DbSet<AccountDeletionRequest> AccountDeletionRequests => Set<AccountDeletionRequest>();
    public DbSet<WebhookEvent> WebhookEvents => Set<WebhookEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CapiStayDbContext).Assembly);
    }
}
