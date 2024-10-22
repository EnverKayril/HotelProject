namespace HotelProject.WebUI.DTOs.BookingDTO
{
    public class ApprovedReservationDTO
    {
        public int? BookingId { get; set; }
        public string? Status { get; set; }
        public string? Mail { get; set; }
        public string? Name { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public string? AdultCount { get; set; }
        public string? ChildCount { get; set; }
        public string? RoomCount { get; set; }
        public string? SpecialRequest { get; set; }
        public string? Description { get; set; }
    }
}
