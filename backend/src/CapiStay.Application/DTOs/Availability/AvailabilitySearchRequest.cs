namespace CapiStay.Application.DTOs.Availability;

public sealed class AvailabilitySearchRequest
{
    public Guid RoomTypeId { get; init; }

    public DateOnly CheckInDate { get; init; }

    public DateOnly CheckOutDate { get; init; }

    public int GuestCount { get; init; }
}