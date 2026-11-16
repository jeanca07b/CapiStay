using CapiStay.Application.DTOs.Availability;
using CapiStay.Application.Services.Availability;

namespace CapiStay.Tests;

public class AvailabilitySearchValidatorTests
{
    private readonly AvailabilitySearchValidator _validator = new();

    [Fact]
    public void Validate_WithValidRequest_DoesNotThrow()
    {
        var request = CreateRequest();

        var exception = Record.Exception(
            () => _validator.Validate(request));

        Assert.Null(exception);
    }

    [Fact]
    public void Validate_WithEmptyRoomTypeId_ThrowsArgumentException()
    {
        var request = CreateRequest(roomTypeId: Guid.Empty);

        Assert.Throws<ArgumentException>(
            () => _validator.Validate(request));
    }

    [Fact]
    public void Validate_WithInvalidDates_ThrowsArgumentException()
    {
        var request = CreateRequest(
            checkIn: new DateOnly(2026, 12, 20),
            checkOut: new DateOnly(2026, 12, 10));

        Assert.Throws<ArgumentException>(
            () => _validator.Validate(request));
    }

    [Theory]
    [InlineData(31)]
    [InlineData(40)]
    public void Validate_WithMoreThan30Nights_ThrowsArgumentException(int nights)
    {
        var request = CreateRequest(
            checkOut: new DateOnly(2026, 12, 10).AddDays(nights));

        Assert.Throws<ArgumentException>(
            () => _validator.Validate(request));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_WithInvalidGuestCount_ThrowsArgumentException(int guestCount)
    {
        var request = CreateRequest(guestCount: guestCount);

        Assert.Throws<ArgumentException>(
            () => _validator.Validate(request));
    }

    [Fact]
    public void Validate_WithExactly30Nights_DoesNotThrow()
    {
        var request = CreateRequest(
            checkOut: new DateOnly(2027, 1, 9));

        var exception = Record.Exception(
            () => _validator.Validate(request));

        Assert.Null(exception);
    }

    private static AvailabilitySearchRequest CreateRequest(
        Guid? roomTypeId = null,
        DateOnly? checkIn = null,
        DateOnly? checkOut = null,
        int guestCount = 2)
    {
        return new AvailabilitySearchRequest
        {
            RoomTypeId = roomTypeId ?? Guid.NewGuid(),
            CheckInDate = checkIn ?? new DateOnly(2026, 12, 10),
            CheckOutDate = checkOut ?? new DateOnly(2026, 12, 13),
            GuestCount = guestCount
        };
    }
}