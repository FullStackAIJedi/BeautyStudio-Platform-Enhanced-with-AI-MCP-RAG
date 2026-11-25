namespace Shop.Domain.Events
{
    public record SalonAppointmentBookedEvent
    {
        public int AppointmentId { get; init; }
        public int ClientId { get; init; }
        public int UserId { get; init; }
        public string ServiceName { get; init; } = default!;
        public decimal ServicePrice { get; init; }
        public DateTime AppointmentDate { get; init; }
        public int LocationId { get; init; }
    }
}
