namespace FootballBooking.Entities.Model
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Guid? BookerId { get; set; }
        public Booker Booker { get; set; }

        public Guid? StadiumId { get; set; }
        public Stadium Stadium { get; set; }

        public override string ToString()
        {
            return $"{Booker?.Name ?? ""} {Street}, {City} {PostalCode}, {Country}";
        }
    }
}