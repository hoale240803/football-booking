namespace FootballBooking.Entities.Model
{
    public class Address: BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string City { get; set; } = null!;
        public string? Region { get; set; }
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public Guid? BookerId { get; set; }
        public Guid? StadiumId { get; set; }

        public virtual User? Booker { get; set; }
        public virtual Stadium? Stadium { get; set; }
    }
}