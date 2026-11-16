using CapiStay.Application.DTOs.Availability;

namespace CapiStay.Application.Services.Availability;

public sealed class AvailabilitySearchValidator
{
    public void Validate(AvailabilitySearchRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.RoomTypeId == Guid.Empty)
            throw new ArgumentException("A valid room type is required.");

        if (request.CheckInDate >= request.CheckOutDate)
            throw new ArgumentException(
                "Check-in date must be earlier than check-out date.");

        var nights = request.CheckOutDate.DayNumber
            - request.CheckInDate.DayNumber;

        if (nights > 30)
            throw new ArgumentException(
                "The maximum stay is 30 nights.");

        if (request.GuestCount <= 0)
            throw new ArgumentException(
                "Guest count must be greater than zero.");
    }
}